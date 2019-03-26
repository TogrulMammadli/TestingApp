using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
