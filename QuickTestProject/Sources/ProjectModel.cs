using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTestProject
{
    [Serializable]
    public class Question
    {
        public string question;
        public bool active = true;
        public List<string> questionPictureFilename;
        public List<string> answersPicturesFilename;
        public List<string> answers;
        public List<int> correctAnswers;
    }

    [Serializable]
    public class ProjectModel
    {
        public bool hasImages;
        public List<Question> questions = new List<Question>();
    }

}
