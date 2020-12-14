using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dbApp.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        [NotMapped]
        private string _email;
        public string Email
        {
            get => _email;
            set {
                if (Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                {
                    _email = value;
                }
                else
                {
                    throw(new ArgumentException());
                }
 }
        }
        public List<ProjectEmployee> ProjectEmployees { get; set; } = new List<ProjectEmployee>();
    }
}