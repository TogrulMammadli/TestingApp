using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Models;
using TestApplicationWPF.Repository.QuestionsRepository;

namespace TestApplicationWPF.Services.QuestionService
{
    public class QuestionService : IQuestionService
    {
        private IQuestionRepository QuestionRepository = new QuestionRepository();

        public QuestionService(IQuestionRepository questionRepository)
        {
            this.QuestionRepository = questionRepository ?? throw new ArgumentNullException(nameof(QuestionRepository));
        }

        public bool AddQuestion(Question question)
        {
            return QuestionRepository.AddQuestion(question);
        }

        public byte[] ConvertImageToByte(string path)
        {
            Image image = Image.FromFile(path);
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            byte[] b = memoryStream.ToArray();
            return b;
        }

        public IEnumerable<Question> GetAllQuestions()
        {
         return   QuestionRepository.GetAllQuestions();
        }

        public string OpenFileGetPath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Images(*.BMP; *.JPG; *.GIF,*.PNG,*.TIFF)| *.BMP; *.JPG; *.GIF; *.PNG; *.TIFF | All files (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName.ToString();
            }
            else return "Error";
        }

       

        public bool RemoveQuestion(Question question)
        {
            try
            {
                QuestionRepository.RemoveQuestion(question);
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

      
        public string GetAvatarImageFromDb(int UID)
        {
            byte[] b;

            b = TestContext.Instance.Questions.Where(x => x.Id == UID).DefaultIfEmpty().Single().Image;
            if (b == null)
            {
                return null;
            }

            Image image1;
            using (var ms = new MemoryStream(b))
            {
                image1 = Image.FromStream(ms);
            }
            image1.Save(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Icons\\" + "QuestionImage", System.Drawing.Imaging.ImageFormat.Bmp);
            return Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Icons\\" + "QuestionImage";


        }
    }
}
