using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : TestBase
    {
        [Test]
        public void RemovalProjectTest()
        {
            List<ProjectData> oldProjects = new List<ProjectData>();
            oldProjects = app.Projects.GetProject();

            if (oldProjects.Count == 0)
            {
                ProjectData project = new ProjectData(GenerateRandomString(10));
                app.Navigator.GoToControlMainPage();
                app.Navigator.GoToProjectControlPage();
                app.Projects.Create(project);
                oldProjects = app.Projects.GetProject();
            }

            app.Navigator.GoToControlMainPage();
            app.Navigator.GoToProjectControlPage();
            app.Projects.Remove();

            List<ProjectData> newProject = app.Projects.GetProject();
            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProject.Sort();
            Assert.AreEqual(oldProjects, newProject);
        }

    }
}
