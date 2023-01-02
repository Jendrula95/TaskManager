using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel;
using TaskManager.Models;


namespace TaskManager.Models
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Opis")]
        public string  Description { get; set; }
        public bool Done { get; set; }
    }
}
