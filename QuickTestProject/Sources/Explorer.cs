using QuickTestProject.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QuickTestProject
{
    [Serializable]
    public class PreviewDocument
    {
        public string name;
        public Question[] questions;
        public bool[][] userAnswers;
        public DateTime writedTime;
    }

    public class PreviewLink
    {
        public bool sync;
        public string filename;
        public PreviewDocument data;
    }

    public class Explorer
    {
        public const int INVALID_ID = 0;

        public delegate void Method1();
        public delegate void Method2(Project prevProject, Project newProjectSet);
        public delegate void Method3(Project project);
        public delegate void Method4(Project project, string prevName);

        public enum ProfileMode
        {
            unlimit,
            limit
        }

        [Serializable]
        public class ProjectAsset
        {
            public string name;
            public string description;
            public string version;
            public string locale;

            public ProjectModel model;
        }

        public class Profile
        {
            public string name;
            public bool mix;
            public ProfileMode mode;
            public int count = 32768;
            public int times;

            public Profile() { }

            public Profile(Profile owner)
            {
                name = owner.name;
                mix = owner.mix;
                mode = owner.mode;
                count = owner.count;
            }
        }

        [Serializable]
        public class ProjectIdentity
        {
            public string projectName;
            public string projectPath;
            public int projectID;
            public int totalQuestions;
            public int totalAnswers;
            public int maxAnswerValues;
            public int totalPictures;
            public int totalRun;
        }
        [Serializable]
        public class HistoryObject
        {
            public string projectName;
            public string projectPath;
            public int projectID;
        }

        [Serializable]
        public class ProjectConfiguration
        {
            public string version;
            public List<Profile> profiles;
            public List<ProjectIdentity> projects;
            public List<HistoryObject> histories;
            public int focused;
            public bool permissionInvalidName;
            public bool hideNumberQuests;
            public bool hideDisallowQuests;
            public int maxHistoryView = 5;
            public bool firstRun = true;
            public bool autoSave = true;
            public int selectedProfile = 0;

            public ProjectConfiguration() { }
        };

        public static Explorer instance;
        public static Modules.Module[] modules = new Modules.Module[] { new Modules.ZIP(), new Modules.Csv(), new Modules.JSON() };
        public static (string, string)[] externalSources = new[] {
            ("https://github.com/badcast",@"Мой GitHub ;)
Заглядывайте за обновлениями"),
            ("https://icons8.ru", "Бесплатные Иконки, иллюстрации, фото, музыка и приложения для дизайна"),
            ("https://github.com/facebook-csharp-sdk/simple-json",
@"
//-----------------------------------------------------------------------
// <copyright file=""SimpleJson.cs"" company=""The Outercurve Foundation"">
//    Copyright (c) 2011, The Outercurve Foundation.
//
//    Licensed under the MIT License (the ""License"");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.opensource.org/licenses/mit-license.php
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an ""AS IS"" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <author>Nathan Totten (ntotten.com), Jim Zimmerman (jimzimmerman.com) and Prabir Shrestha (prabir.me)</author>
// <website>https://github.com/facebook-csharp-sdk/simple-json</website>
//-----------------------------------------------------------------------"),
            ("https://web.archive.org/web/20160803235150/http://tradeincome.ru/useful-content/RFC%204180%20rus.pdf",@"Нажмите на сылку, чтобы скачать книгу. Общий формат и MIME-тип для файлов значений, разделенных
запятыми (CSV)
Статус этого документа
В этом документе содержится информация для интернет-сообщества. Он не определяет
Internet-стандарта любого рода. Распространение этого документа не ограничено.
Уведомление об авторских правах
Copyright © Internet Society (2005")

        };
        public static string projectFileExtension = ".quix";
        public static string projectExtensionFilter = string.Format("Project Files|*{0}", projectFileExtension);
        public static System.Globalization.CultureInfo applicationCulture = System.Globalization.CultureInfo.CurrentCulture;
        public static ProjectConfiguration projectConfiguration;
        public static Profile defaultProfile = new Profile() { count = 120, mode = ProfileMode.unlimit, name = "(по умолчанию)", mix = true };
        public static List<PreviewLink> previews = new List<PreviewLink>();
        public static Project createEmptyProject(int id = INVALID_ID)
        {
            Project p = new Project(id == INVALID_ID ? makeNewID() : id);
            p.name = "New Project";
            p.version = version;
            p.locale = applicationCulture.Name;
            return p;
        }
        public static string normalProjectFileName(string s, bool onlyFileChars = false)
        {
            char[] invalids = System.IO.Path.GetInvalidFileNameChars();
            char[] cx = s.ToCharArray();
            for (int x = 0; x < s.Length; ++x)
            {
                if (!onlyFileChars && (char.IsSymbol(s[x]) || char.IsPunctuation(s[x]) || char.IsSeparator(s[x])) ||
                    invalids.Any((y) => s[x] == y))
                    cx[x] = '_';
            }
            return new string(cx);
        }
        public static bool hasInvalidChars(string s, bool onlyFileChars = false)
        {
            char[] invalids = System.IO.Path.GetInvalidFileNameChars();
            return s.Any((x) => !onlyFileChars && (char.IsSymbol(x) || char.IsPunctuation(x)) || invalids.Any((y) => x == y)); ;
        }

        public static string applicationDirectory()
        {
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\QuickTest";
            Directory.CreateDirectory(path);
            return path;
        }
        public static string projectDirectory()
        {
            string path = applicationDirectory() + "\\Projects";
            Directory.CreateDirectory(path);
            return path;
        }

        public static string getPreviewResultDirectory()
        {
            string path = applicationDirectory() + "\\Previews";
            Directory.CreateDirectory(path);
            return path;
        }

        public static int makeNewID()
        {
            int id = 0;
            Random y = new Random((int)DateTime.Now.Ticks);
            do
            {
                id = y.Next();
            } while (projects.Any((x) => x.projectID == id));
            return id;
        }

        public static string projectConfigurationFile { get { return applicationDirectory() + "\\settings.json"; } }
        public const string version = "1.0.0";
        public const string defaultLabel = "Quest #";
        public static List<Project> projects = new List<Project>();
        public int currentProjectIndex { get => getProjectIndex(currentProject); }

        public Project currentProject;
        public Project lastFocusedProject;
        public MainForm mainForm;

        public event Method1 onProjectListChanged;
        public event Method2 onProjectFocusChanged;
        public event Method1 onPreviewDocumentListChanged;

        OpenFileDialog opf = new OpenFileDialog();
        SaveFileDialog svf = new SaveFileDialog();

        public Explorer(MainForm mainForm)
        {
            instance = this;
            this.mainForm = mainForm;
            projectConfiguration = new ProjectConfiguration()
            {
                version = Explorer.version,
                profiles = new List<Profile>(),
                histories = new List<HistoryObject>(),
                projects = new List<ProjectIdentity>()
            };
        }

        public void init()
        {
            Project proj;
            ProjectAsset asset;
            string x = projectConfigurationFile;
            int y;
            int z;

            if (File.Exists(x))
            {
                projectConfiguration = JSON.deserialize<ProjectConfiguration>(File.ReadAllText(x));
                if (projectConfiguration.version != version)
                {
                    // TODO: unequal version
                }

                projectConfiguration.projects = projectConfiguration.projects ?? new List<ProjectIdentity>();
                projectConfiguration.projects.RemoveAll((f) => f == null || string.IsNullOrEmpty(f.projectPath) ||
                        !File.Exists(f.projectPath));
                projectConfiguration.histories = projectConfiguration.histories ?? new List<HistoryObject>();
                projectConfiguration.histories.RemoveAll(f => f == null || f.projectID == INVALID_ID);
                projectConfiguration.profiles = projectConfiguration.profiles ?? new List<Profile>();

                for (y = 0; y < projectConfiguration.projects.Count; ++y)
                {
                    if (!checkProjectFile(projectConfiguration.projects[y].projectPath, out asset))
                        continue;
                    //valid id
                    z = projectConfiguration.projects[y].projectID;
                    z = z == INVALID_ID ? makeNewID() : z;
                    proj = createEmptyProject(z);
                    proj.filename = projectConfiguration.projects[y].projectPath;
                    proj.addFromAsset(asset);
                    proj.pushChange(false);
                    registerProjectInRuntime(proj, false);
                }


                proj = findProjectFromID(projectConfiguration.focused);
                if (proj != null)
                {
                    y = getProjectIndex(proj);
                    focusProject_internal(y);
                }
                else
                {
                    projectConfiguration.focused = INVALID_ID;
                }
            }

            //add default profile
            if (projectConfiguration.profiles.Count == 0)
                projectConfiguration.selectedProfile = 0;
            projectConfiguration.profiles.Insert(0, defaultProfile);

            //load previews
            loadPreviews();
        }

        public void loadPreviews()
        {
            string dir = getPreviewResultDirectory();
            foreach (var x in Directory.EnumerateFiles(dir))
            {
                if (Path.GetExtension(x).ToLower() != ".json")
                    continue;
                string json = File.ReadAllText(x);
                PreviewDocument pr = JSON.deserialize<PreviewDocument>(json);
                PreviewLink lnk = new PreviewLink();
                lnk.filename = Path.GetFileName(x);
                lnk.sync = true;
                lnk.data = pr;
                previews.Add(lnk);
            }
        }

        public void addPreview(PreviewDocument pr)
        {
            PreviewLink lnk = new PreviewLink();
            lnk.sync = false;
            lnk.data = pr;
            previews.Add(lnk);
            savePreviews(); // auto sync
            onPreviewDocumentListChanged?.Invoke();
        }

        public bool toArchive(PreviewLink documentLink)
        {
            int i = previews.IndexOf(documentLink);
            int x;
            if (i != -1 && documentLink.sync)
            {
                //previews.RemoveAt(i);
                //TODO: goto archive
                string path = getPreviewResultDirectory() + "\\Archives";
                Directory.CreateDirectory(path);
                string fname = Path.GetFileNameWithoutExtension(documentLink.filename);
                x = 0;
                string newlocate;
                do
                {
                    ++x;
                    newlocate = path + "\\" + fname + x.ToString() + ".zip";
                } while (File.Exists(newlocate));

                using (var zip = ZIP.open(newlocate, System.IO.Compression.ZipArchiveMode.Create))
                {
                    using (var entry = new StreamWriter(zip.CreateEntry(documentLink.filename).Open()))
                    {
                        string content = File.ReadAllText(getPreviewResultDirectory() + "\\" + documentLink.filename);
                        entry.Write(content);
                    }
                }
                removePreview(documentLink);
            }
            return i != -1 && documentLink.sync;
        }

        public bool removePreview(PreviewLink documentLink)
        {
            int i = previews.IndexOf(documentLink);
            if (i != -1)
            {
                previews.RemoveAt(i);
                File.Delete(getPreviewResultDirectory() + "\\" + documentLink.filename);
                onPreviewDocumentListChanged?.Invoke();
            }
            return i != -1;
        }

        public int removePreviews(PreviewLink[] previewLinks)
        {
            int x, y = 0, i;

            for (x = 0; x < previewLinks.Length; ++x)
            {
                i = previews.IndexOf(previewLinks[x]);
                if (i != -1)
                {
                    previews.RemoveAt(i);
                    File.Delete(getPreviewResultDirectory() + "\\" + previewLinks[x].filename);
                    ++y;
                }
            }
            if (y > 0)
                onPreviewDocumentListChanged?.Invoke();
            return y;
        }

        public void savePreviews()
        {
            string dir = getPreviewResultDirectory();
            string fname;
            for (int x = 0; x < previews.Count; ++x)
            {
                if (previews[x].sync)
                    continue;
                fname = previews[x].filename;
                if (string.IsNullOrEmpty(fname))
                {
                    fname = string.Format("preview_{0}_{1}_{2}", (x + 1), previews[x].data.writedTime.ToShortDateString(), ".json");
                }
                try
                {
                    string json = JSON.serialize(previews[x].data);
                    File.WriteAllText(dir + "\\" + fname, json);
                }
                catch
                {

                }
                previews[x].sync = true;
                previews[x].filename = fname;
            }
        }
        public bool requireSave(out Project[] projList)
        {
            projList = projects.Where(f => f.requireSave).ToArray();
            return projList.Length != 0;
        }

        bool removeHistroy(Project project)
        {
            return projectConfiguration.histories.RemoveAll((f) => f.projectID == project.projectID) > 0;
        }
        void add_history(Project project, string path)
        {
            HistoryObject x;
            int y;
            if (string.IsNullOrEmpty(path))
                return;
            projectConfiguration.histories = projectConfiguration.histories ?? new List<HistoryObject>();
            y = projectConfiguration.histories.FindIndex((f) => f.projectID == project.projectID && f.projectName == project.name && f.projectPath == path);
            if (y == -1)
            {
                projectConfiguration.histories.Insert(0, x = new HistoryObject() { projectName = project.name, projectPath = path, projectID = project.projectID });
            }
            else
            {
                //Rechange Index
                x = projectConfiguration.histories[0];
                projectConfiguration.histories[0] = projectConfiguration.histories[y];
                projectConfiguration.histories[y] = x;
            }
        }

        public bool unregisterProjectInRuntime(Project project, bool removeHistory = true)
        {
            int x = getProjectIndex(project);
            if (project != null && x != -1)
            {
                projects.RemoveAt(x);
                if (removeHistory)
                    removeHistroy(project);
                projectConfiguration.projects.RemoveAll((f) => f.projectID == project.projectID);
                focusProject_internal(-1);
                onProjectListChanged?.Invoke();
                return true;
            }
            return false;
        }
        public bool registerProjectInRuntime(Project project, bool saveHistory = true)
        {
            if (project != null)
            {
                if (!projects.Any((f) => f.projectID == project.projectID && f.name == project.name && f.filename == project.filename))
                {
                    projects.Add(project);
                    //ad history registry
                    if (saveHistory)
                        add_history(project, project.filename);
                    onProjectListChanged?.Invoke();
                    return true;
                }
            }
            return false;
        }
        bool checkProjectFile(string projectFile, out ProjectAsset projectAsset)
        {
            string errors = "";
            projectAsset = null;

            var zip = ZIP.open(projectFile);
            if (zip != null)
            {
                var entry = zip.GetEntry("entity.json");
                using (var json = new StreamReader(entry.Open()))
                {
                    ProjectAsset asset = JSON.deserialize<ProjectAsset>(json.ReadToEnd());

                    if (string.IsNullOrEmpty(asset.locale))
                        errors += "Project Locale is not defined;\n";

                    if (asset.version != version)
                    {
                        errors += "Projet Vesion is not supported;\n";
                    }
                    else
                    {
                        projectAsset = asset;
                    }
                }
                zip.Dispose();
            }
            return projectAsset != null;
        }
        void showDialogOpen(string caption, string extensions, string defaultDir = "")
        {
            opf.Title = caption;
            opf.Filter = extensions;
            ProjectAsset projAsset;

            if (!string.IsNullOrEmpty(defaultDir))
                opf.InitialDirectory = defaultDir;

            if (opf.ShowDialog(mainForm) != DialogResult.OK)
                return;

            if (checkProjectFile(opf.FileName, out projAsset))
            {
                Project projLoaded = createEmptyProject();
                projLoaded.name = projAsset.name;
                projLoaded.version = projAsset.version;
                projLoaded.locale = projAsset.locale;
                projLoaded.filename = opf.FileName;
                projLoaded.addFromAsset(projAsset);
                if (!registerProjectInRuntime(projLoaded))
                    MessageBox.Show("Данный проект уже существует в системе.");
                else
                    focusProjectFromID(projLoaded.projectID);
            }
        }

        public int getProjectIndex(Project proj)
        {
            return projects.IndexOf(proj);
        }

        public Question[] getQuestionsByFilter(Project target, bool randomize, bool hasMultiAnswers, int count = -1)
        {
            int x;
            int z;
            int w;
            int[] pointer = null;
            List<Question> prototypes = target.model.questions;
            List<Question> filtered = new List<Question>();

            Random rnd = null;

            if (randomize)
            {
                rnd = new Random((int)DateTime.Now.Ticks);
                pointer = new int[target.questionCount];

                for (x = 0; x < target.questionCount; ++x)
                    pointer[x] = x;

                //random for list
                for (x = 0; x < target.questionCount; ++x)
                {
                    z = rnd.Next(x, target.questionCount);
                    int tmp = pointer[z];
                    pointer[z] = pointer[x];
                    pointer[x] = tmp;
                }
            }

            count = count == -1 ? prototypes.Count : count;
            //get a filtering 
            for (x = 0; filtered.Count < count && x < target.questionCount; ++x)
            {
                Question y = prototypes[randomize ? pointer[x] : x];
                //finded multi answers
                if (!y.active || y.correctAnswers.Count > 1 && !hasMultiAnswers)
                    continue;

                List<int> newCorrectedAnswers = new List<int>(y.correctAnswers);
                string[] newAnswers = y.answers.ToArray();

                if (randomize)
                {
                    for (w = newCorrectedAnswers.Count; w < newAnswers.Length; ++w)
                        newCorrectedAnswers.Add(-1);

                    if (y.correctAnswers.Count == 1)
                    {
                        z = newCorrectedAnswers[0];
                        newCorrectedAnswers[0] = -1;
                        newCorrectedAnswers[z] = z;
                    }

                    for (w = 0; w < newAnswers.Length; ++w)
                    {
                        z = rnd.Next(w, y.answers.Count);

                        string tmp = newAnswers[z];
                        int tmp0 = newCorrectedAnswers[z];
                        newAnswers[z] = newAnswers[w];
                        newCorrectedAnswers[z] = newCorrectedAnswers[w];
                        newAnswers[w] = tmp;
                        newCorrectedAnswers[w] = tmp0;
                    }

                    for (w = 0; w < newCorrectedAnswers.Count; ++w)
                        if (newCorrectedAnswers[w] != -1)
                            newCorrectedAnswers[w] = w;

                    //to paths
                    if (y.correctAnswers.Count == 1)
                        newCorrectedAnswers.RemoveAll((f) => f == -1);


                }

                Question v = new Question();
                v.question = y.question;
                v.active = y.active;
                v.questionPictureFilename = y.questionPictureFilename;
                v.answers = new List<string>(newAnswers);
                v.correctAnswers = newCorrectedAnswers;
                newCorrectedAnswers.TrimExcess();
                filtered.Add(v);
            }

            return filtered.ToArray();
        }

        public void saveAll(bool nullpath_save_to_dirs = false, bool showdir_for_nullpaths = false)
        {
            int x;
            Project[] projs;
            requireSave(out projs);
            for (x = 0; x < projs.Length; ++x)
            {
                if (string.IsNullOrEmpty(projs[x].filename))
                {
                    string format = "{0}\\{1}{2}{3}";
                    int numerator = 0;
                    string filename = string.Format(format, projectDirectory(), normalProjectFileName(projs[x].name), numerator == 0 ? "" : numerator.ToString(), projectFileExtension);

                    if (showdir_for_nullpaths)
                    {
                        saveProjectAsDlg(projs[x], filename);
                        continue;
                    }
                    else
                    if (nullpath_save_to_dirs)
                    {

                        while (File.Exists(filename))
                        {
                            ++numerator;
                            filename = string.Format(format, projectDirectory(), normalProjectFileName(projs[x].name), numerator == 0 ? "" : numerator.ToString(), projectFileExtension);
                        }
                        projs[x].filename = filename;
                    }
                    else
                        continue;
                }

                saveProject(projs[x]); // go save
                projs[x].pushChange(false); // reset changes
            }
        }

        public bool check_autosave()
        {
            Project[] projs;
            return projectConfiguration.autoSave && requireSave(out projs);
        }

        public Project focusProjectFromID(int id)
        {
            return focusProject_internal(getProjectIndex(findProjectFromID(id)));
        }
        public Project focusProject_internal(int projectIndex)
        {
            lastFocusedProject = currentProject;
            currentProject = projectIndex == -1 ? null : projects[projectIndex];
            onProjectFocusChanged?.Invoke(lastFocusedProject, currentProject);
            projectConfiguration.focused = currentProject == null ? INVALID_ID : currentProject.projectID;
            return currentProject;
        }

        public Project findProjectFromID(int id)
        {
            return projects.Find((f) => f.projectID == id);
        }

        public Project findProject(string projectName)
        {
            return projects.Find((f) => f.name == projectName);
        }

        public void createNewProject()
        {
            Project p;
            CreateNewProjectForm form = new CreateNewProjectForm();
            form.Icon = mainForm.Icon;
            form.Text = string.Format(MainForm.captionFormat, "Создание нового проекта");

            if (!form.show(mainForm, out p))
                return;
            p.pushChange();
            registerProjectInRuntime(p, false);
            focusProjectFromID(p.projectID);
            mainForm.updateProjectList();
        }

        public void createNewFromDefaultTemplate()
        {
            MessageBox.Show("Пока шаблоны не поддерживаются.");
        }

        public void createNewFromTemplate(Project template)
        {
            MessageBox.Show("Пока шаблоны не поддерживаются.");
        }

        public void openProjectFile()
        {
            showDialogOpen("Выберите проект", projectExtensionFilter, projectDirectory());
        }

        public void saveProject(Project proj)
        {
            saveProjectAs(proj, proj.filename);
        }

        public void saveProjectAs(Project project, string newPath)
        {
            ProjectAsset asset = project.asAsset();

            string json = JSON.serialize(asset);
            if (File.Exists(newPath))
                File.Delete(newPath);
            using (var zip = ZIP.open(newPath, System.IO.Compression.ZipArchiveMode.Create))
            {
                var entry = zip.CreateEntry("entity.json", System.IO.Compression.CompressionLevel.Fastest);
                using (StreamWriter sw = new StreamWriter(entry.Open()))
                    sw.Write(json);
#if !DEBUG 
                //create caches (for upsize)
                byte[] _buf = new byte[4092];
                System.Security.Cryptography.RandomNumberGenerator n = System.Security.Cryptography.RandomNumberGenerator.Create();
                for (char i = 'a'; i <= 'z'; ++i)
                {
                    entry = zip.CreateEntry("locale/total_" + (char)i);
                    using (var b = new BinaryWriter(entry.Open()))
                    {
                        n.GetBytes(_buf);
                        b.Write(_buf);
                    }
                }
#endif
            }

            project.filename = newPath;
            project.pushChange(false);
        }

        public void saveProjectAsDlg(Project project, string defaultDir = null)
        {
            if (project == null)
            {
                MessageBox.Show("Проект не выбран для сохранения");
                return;
            }

            svf.Title = "Сохранение проекта как ...";
            svf.Filter = projectExtensionFilter;
            svf.InitialDirectory = defaultDir ?? projectDirectory();
            svf.FileName = (string.IsNullOrEmpty(project.filename) ? project.name : Path.GetFileNameWithoutExtension(project.filename)) + projectFileExtension;
            if (svf.ShowDialog(mainForm) != DialogResult.OK)
                return;

            saveProjectAs(project, svf.FileName);
        }

        public void saveProjectTemplate()
        {
            svf.Title = "Экспорт шаблона таблицы (для импорта)";
            svf.Filter = "CSV|*.csv";

            if (svf.ShowDialog() != DialogResult.OK)
                return;

            Csv.saveTemplate(svf.FileName);
        }

        public void importTestCsv()
        {
            int x, y, z = 0;
            Project importedProject;

            opf.Filter = "CSV|*.csv";
            opf.Title = "Импорт";
            if (opf.ShowDialog() != DialogResult.OK)
                return;

            string name = Path.GetFileNameWithoutExtension(opf.FileName);
            
            var document = Csv.getrows(opf.FileName);
            importedProject = createEmptyProject();

            for (x = 0; x < document.Count; ++x)
            {
                string[] row = document[x];
                Question question = new Question();
                question.question = row[0];//get first column (question) 
                question.answers = new List<string>();
                //get's anwers
                for (y = 1; y < row.Length - 1; ++y)
                    question.answers.Add(row[y]);

                //get's correct answer or answers (index or multi-index) 
                string[] corrAnsw = row[y].ToLower().Trim(' ', '\t').Split(',', ';');
                question.correctAnswers = new List<int>();
                if (corrAnsw.Length > 0)
                {
                    //type:
                    //      0 is numbers
                    //      1 is words
                    int type = char.IsNumber(corrAnsw[0][0]) ? 0 : 1;
                    for (y = 0; y < corrAnsw.Length; ++y)
                    {
                        switch (type)
                        {
                            case 0: //type numbers
                                z = (int)corrAnsw[y][0] - '1';
                                break; // type words
                            case 1:
                                z = (int)corrAnsw[y][0] - 'a';
                                break;
                        }
                        question.correctAnswers.Add(z);
                    }
                }

                importedProject.model.questions.Add(question);
            }

            importedProject.name = "Импортированный проект - " + name;
            registerProjectInRuntime(importedProject); // add project
        }

        public void exportTestCsv()
        {

        }
        public void queryQuit()
        {
            int x;
            Project[] projs;
            //update project config info
            try
            {
                if (projectConfiguration.autoSave && requireSave(out projs))
                {
                    saveAll();
                }
            }
            catch (Exception ex)
            {

            }

            projectConfiguration.projects = projectConfiguration.projects ?? new List<ProjectIdentity>();
            for (x = 0; projectConfiguration.projects?.Count < projects.Count; ++x)
                projectConfiguration.projects.Add(null);

            if (projectConfiguration.profiles.Count > 0)
                projectConfiguration.profiles.RemoveAt(0); // delete default profile

            for (x = 0; x < projects.Count; ++x)
            {
                ProjectIdentity pi = projectConfiguration.projects[x] ?? new ProjectIdentity();
                pi.totalPictures = projects[x].totalPictures;
                pi.totalQuestions = projects[x].questionCount;
                pi.totalAnswers = projects[x].totalAnswers;
                pi.maxAnswerValues = projects[x].maxAnswersCount;
                pi.projectName = projects[x].name;
                pi.projectPath = projects[x].filename;
                pi.projectID = projects[x].projectID;
                projectConfiguration.projects[x] = pi;
            }
            File.WriteAllText(projectConfigurationFile, JSON.serialize(projectConfiguration));

            //save previews
            savePreviews();
        }

        public void showProfileDialog()
        {
            TestRunnerForm tstRunner;

            tstRunner = new TestRunnerForm();
            tstRunner.StartPosition = FormStartPosition.CenterScreen;
            //            tstRunner.setFlag(this, this.currentProject);
            mainForm.Hide();

            tstRunner.show(this, currentProject);

            mainForm.Show();
        }

        public void openPreview(PreviewDocument previewDocument, bool fullscreen)
        {
            Runner runner;

            if (previewDocument == null)
                throw new ArgumentNullException();

            runner = new Runner();
            try
            {
                runner.showAsPreview(previewDocument, fullscreen);
            }
            finally
            {
            }
        }

        public void run(bool fullscreen, Profile profile = null)
        {
            Runner runner;

            if (currentProject.questionCount == 0)
            {
                MessageBox.Show("Проект \"" + currentProject.name + "\" совершенно пуст. " +
                    "\n\tСовет: Добавьте вопросов в окне \"Конструктор\" или импортируйте готовые тесты, либо выберите другой проект.");
                return;
            }

            profile = profile ?? projectConfiguration.profiles[projectConfiguration.selectedProfile];

            runner = new Runner();
            Question[] evaled = getQuestionsByFilter(currentProject, profile.mix, true, profile.count);

            PreviewDocument p = runner.show(profile, evaled, fullscreen);
            addPreview(p);
        }
    }
}
