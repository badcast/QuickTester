using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTestProject
{

    public class Project
    {
        int _projectID;
        bool childChanged;

        public ProjectModel model;
        public string filename;
        public string description;
        public string name;
        public string version;
        public string locale;

        public bool isLoaded { get { return model != null; } }
        public int questionCount { get => model.questions.Count; }
        public int totalAnswers
        {
            get
            {
                int x;
                int y = 0;
                for (x = 0; x < questionCount; ++x)
                {
                    List<string> answ = getNativeQuestion(x).answers;
                    y += answ != null ? answ.Count : 0;
                }

                return y;
            }
        }
        public int maxAnswersCount { get; }
        public int totalPictures { get; }
        public int projectID { get => _projectID; }
        public bool requireSave
        {
            get
            {
                return string.IsNullOrEmpty(filename) || childChanged;
            }
        }


        public Project(int projectID)
        {
            model = new ProjectModel();
            if (projectID == Explorer.INVALID_ID)
            {
                throw new Exception(nameof(Explorer.INVALID_ID));
            }
            this._projectID = projectID;
        }
        public void addAnswers(int qu, params string[] answers)
        {
            Question q = model.questions[qu];
            q.answers.AddRange(answers); // concat
            pushChange();
        }
        public bool deleteAnswer(int qu, string answerFrom)
        {
            Question q = model.questions[qu];
            pushChange();
            return q.answers.Remove(answerFrom);
        }
        public int addQuestion(bool active, string question, List<string> answers, List<int> correctAnswers, Bitmap questionPicture = null, Bitmap[] answersPictures = null)
        {
            Question newQuestion = new Question();
            newQuestion.active = active;
            newQuestion.question = question;
            newQuestion.answers = new List<string>(answers);
            if (correctAnswers != null)
                newQuestion.correctAnswers = new List<int>(correctAnswers);
            if (questionPicture != null)
            {
                //TODO: добавить картинку к вопросу
            }

            if (answersPictures != null)
            {
                //TODO: добавить картинки к ответам
            }

            model.questions.Add(newQuestion);
            pushChange();
            return model.questions.Count - 1;
        }

        public void deleteQuestion(int qu)
        {
            model.questions.RemoveAt(qu);
            pushChange();
        }

        public Question getNativeQuestion(int qu)
        {
            pushChange();
            return model.questions[qu];
        }

        public Explorer.ProjectAsset asAsset()
        {
            Explorer.ProjectAsset asset = new Explorer.ProjectAsset
            {
                name = name,
                version = version,
                model = model,
                locale = locale,
                description = description
            };
            return asset;
        }

        public void addPreview(string previewfilename)
        {
            //TODO: add Preview 
        }
        public bool addFromAsset(Explorer.ProjectAsset asset)
        {
            bool x = false;
            int y;
            this.name = asset.name;
            this.description = asset.description;
            this.locale = asset.locale;
            this.version = asset.version;
            if (asset != null)
            {
                for (y = 0; y < asset.model.questions.Count; ++y)
                {
                    Question z = asset.model.questions[y];
                    addQuestion(z.active, z.question, z.answers, z.correctAnswers);
                }
            }
            return x;
        }

        /// <summary>
        /// Send notify a member change
        /// </summary>
        public void pushChange(bool state = true)
        {
            childChanged = state;
        }

        public override string ToString()
        {
            return this.name + " " + projectID;
        }

        /*
        public static bool operator ==(Project x, Project y)
        {
            object a = x;
            object b = y;
            return a != null && b != null && x.caption == y.caption && x.version == y.version && x.model == y.model;
        }
        public static bool operator !=(Project x, Project y)
        {
            return !(x == y);
        }*/
    }
}
