using System;
using System.Collections.Generic;
using System.Text.Json;

namespace SpecIt.Models
{
    public class Project
    {
        public static Project Empty = new Project();
        public string Name { get; set; }
        public List<Income> Incomes { get; set; } = new();
        public List<Expense> Expenses { get; set; } = new();
    }

    public static class ProjectExtensions
    {
        public static string SerializeProject(this Project project)
        {
            return Convert.ToBase64String(JsonSerializer.SerializeToUtf8Bytes(project));
        }

        public static Project DeserializeProject(this string serializedData)
        {
            return JsonSerializer.Deserialize<Project>(Convert.FromBase64String(serializedData));
        }
    }
}