using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Category: IBaseEntity
    {
        private static int index = 1;
        private string _name;
        private string _description;
        private string _updatedBy;

        public Category()
        {
            EnteredOn = DateTime.Now;
        }
        public Category(string name, string description):this()
        {
            Name = name;
            Description = description;
            Id = index;
            index = index + 1;
        }

        public Category(int id, string name, string description, string updatedBy):this()
        {
            Name = name;
            Description = description;
            UpdatedOn = DateTime.Now;
            UpdatedBy = updatedBy;
            Id = id;
        }
        public int Id { get; set; }

        public string UpdatedBy
        {
            get { return _updatedBy; }
            set {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(value,"Give name of updating authority");
                }
                _updatedBy = value; 
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(value, "Name  can't be null");
                }
                _name = value;
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(value,"Description can't be null");
                }
                _description = value;
            }
        }


        public DateTime EnteredOn { get; private set; }
        public DateTime UpdatedOn { get; set; }
        public Product[] Products { get; set; } = new Product[10];

        public override string ToString()
        {            
            return $"Category Id: {Id}, Category Name: {Name}, Category Description: {Description},  Category Entered on {EnteredOn}";
        }
    }
}
