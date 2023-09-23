using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            
            List<ProjectData> oldProjects = new List<ProjectData>();
            oldProjects = app.Projects.GetProject();

            ProjectData project = new ProjectData(GenerateRandomString(10));
            app.Navigator.GoToControlMainPage();
            app.Navigator.GoToProjectControlPage();
            app.Projects.Create(project);

            List<ProjectData> newProject = app.Projects.GetProject();
            oldProjects.Add(project);
            oldProjects.Sort();
            newProject.Sort();
            Assert.AreEqual(oldProjects, newProject);

        }
    }
}
