using Microsoft.AspNetCore.Mvc;


   
    [Route("api/animals")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        
        
        [HttpGet]
        public IActionResult GetAnimals()
        {
            return Ok(Database.Animals);
        }
        
        
        [HttpGet("{id:int}")]
        public IActionResult GetAnimal(int id)
        {
            var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null) return NotFound();
            return Ok(animal);
        }

        [HttpPost]
        public IActionResult AddAnimal(Animal animal)
        {
            animal.Id = Database.Animals.Max(a => a.Id) + 1;
            Database.Animals.Add(animal);
            return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
        }
        
        [HttpPut("{id:int}")]
        public IActionResult UpdateAnimal(int id, Animal updated)
        {
            var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null) return NotFound();

            animal.Name = updated.Name;
            animal.Category = updated.Category;
            animal.Weight = updated.Weight;
            animal.ColorFurniture = updated.ColorFurniture;

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteAnimal(int id)
        {
            var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null) return NotFound();

            Database.Animals.Remove(animal);
            return NoContent();
        }
        
        [HttpGet("search")]
        public IActionResult SearchByName([FromQuery] string name)
        {
            var results = Database.Animals
                .Where(a => a.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
            return Ok(results);
        }
        
        
       

        
        
    }
    
        

