using Microsoft.AspNetCore.Mvc;


[Route("api/animals/{animalId:int}/visits")]
[ApiController]
public class VisitController : ControllerBase
{
    [HttpPost]
    public IActionResult AddVisit(int animalId, [FromBody] Visit visit)
    {
        var animal = Database.Animals.FirstOrDefault(a => a.Id == animalId);
        if (animal == null) return NotFound();

        visit.Id = Database.Visits.Any() ? Database.Visits.Max(v => v.Id) + 1 : 1;
        visit.AnimalId = animalId;
        Database.Visits.Add(visit);

        return CreatedAtAction(nameof(GetVisits), new { animalId }, visit);
    }

    [HttpGet]
    public IActionResult GetVisits(int animalId)
    {
        var animal = Database.Animals.FirstOrDefault(a => a.Id == animalId);
        if (animal == null)
            return NotFound();
        
        var visits = Database.Visits.Where(v => v.AnimalId == animalId).ToList();
        return Ok(visits);

    }
}