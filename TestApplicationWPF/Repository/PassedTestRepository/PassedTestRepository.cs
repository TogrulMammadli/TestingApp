﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.PassedTestRepository
{
    class PassedTestRepository : IPassedTestRepository
    {
        public bool AddPassedTest(PassedTests question)
        {
            using (var c = new TestContext())
            {
                try
                {
                    c.PassedTests.Add(question);
                    c.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
        }

        public IEnumerable<PassedTests> GetAllPassedTests()
        {
            using (var c = new TestContext())
            {
                return c.PassedTests;
            }
        }

        public bool RemovePassedTestById(int Id)
        {
            using (var c = new TestContext())
            {
                foreach (var test in c.PassedTests)
                {
                    if (test.Id == Id)
                    {
                        c.PassedTests.Remove(test);
                        return true;
                    }
                }
                MessageBox.Show("Не было найдено данного id!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
        }
    }
}
