using System.ComponentModel.DataAnnotations;

namespace CS04_Coding_Assignment.Models
{
    public class Todo
    {

        public Guid? Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsComplete { get; set; }

        public DateTime? CreatedOnDate { get; set; }

        public DateTime? UpdatedOnDate { get; set; }

        public void SetCreatedDate()
        {

            this.CreatedOnDate = DateTime.Now;

        }

        public void SetUpdatedDate()
        {
            this.UpdatedOnDate = DateTime.Now;

        }


    }

}
