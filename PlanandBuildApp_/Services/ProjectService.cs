using System;
using System.Collections.Generic;
using System.Text;
using PlanandBuildApp_.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using PlanandBuildApp_.ViewModels;
using PlanandBuildApp_.Views;


namespace PlanandBuildApp_.Services
{
    public class ProjectService 
    {
        FirebaseClient client;
        public ProjectService()
        {
            client = new FirebaseClient("https://planandbuildapp-72e6e-default-rtdb.firebaseio.com");

        }
        public ObservableCollection<Projects> getProject()
        {
            var project_Data = client.Child("Projects").AsObservable<Projects>().AsObservableCollection();

            return project_Data;
        }

        public async Task Add_Project(string projectName, string tools, string steps)
        {
            Projects p = new Projects() { Project_Name = projectName, Tools = tools, Steps = steps };
            await client.Child("Projects").PostAsync(p);
        }
        public async Task Update_Project(string projectName, string tools, string steps)
        {
            var toUpdate_Project = (await client.Child("Projects").OnceAsync<Projects>()).FirstOrDefault
                (a => a.Object.Project_Name == projectName);

            Projects p = new Projects() { Project_Name = projectName, Tools = tools, Steps = steps };
            await client.Child("Projects")
                .Child(toUpdate_Project.Key)
                .PutAsync(p);
        }

        public async Task Delete_Project(string projectName, string tools, string steps)
        {
            var toDelete_Recipe = (await client.Child("Projects").OnceAsync<Projects>()).FirstOrDefault
                (a => a.Object.Project_Name == projectName || a.Object.Tools == tools || a.Object.Steps == steps);
            await client.Child("Projects").Child(toDelete_Recipe.Key).DeleteAsync();

        }


    }
}
