using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager)
        {
        }

        internal void Create(ProjectData project)
        {
            InitProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();

        }

        private void SubmitProjectCreation()
        {
           driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();

        }

        private void InitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='создать новый проект']")).Click();
        }

        private void FillProjectForm(ProjectData project)
        {

            Type(By.Name("name"), project.Name);
            Type(By.Name("description"), project.Description);
        }

        public List<ProjectData> GetProject()
        {
            List<ProjectData> projects = new List<ProjectData>();
            manager.Navigator.GoToControlMainPage();
            manager.Navigator.GoToProjectControlPage();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tbody//tr//a"));
            foreach (IWebElement element in elements)
            {
                projects.Add(new ProjectData(element.Text));
            }

            return projects;

        }

        public void Remove()
        {
            SelectProject();
            SubmitProjectRemoving();
            RemoveProject();
        }

        private void RemoveProject()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }

        private void SubmitProjectRemoving()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }


        private void SelectProject()
        {
            driver.FindElement(By.XPath("(//tbody//tr//td//a)[1]")).Click();
        }
    }
}
