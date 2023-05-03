using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace QuickTestProject.Modules
{
    public struct CreateTestFromTextFile
    {
            static void CreateFromFile(string path, Explorer explorer) {
            int j, x, y, w;
            y = 0;
            using (var sr = new StreamReader(File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                Project project = Explorer.createEmptyProject();
                List<Question> questions = project.model.questions;
                char[] filter = new[] { '2', '3', '4', '5', '6', '7', '8', '9', '1', '0', '.', ' ' };
                string[] lines = new string[32];
                while (!sr.EndOfStream)
                {
                    Question q = new Question();
                    string line;
                    j = 0;
                    w = -1;
                    do
                    {
                        line = sr.ReadLine().TrimStart().TrimStart(filter).TrimEnd();
                        y++; // lines
                        if (line.Length == 0)
                            continue;
                        if (line.StartsWith("*") || sr.EndOfStream)
                            break;

                        x = line.LastIndexOf("//");
                        if (x != -1)
                            line = line.Remove(x, line.Length - x);
                        x = line.IndexOf('+');
                        if (x != -1)
                        {
                            w = j - 1;
                            line = line.Remove(x, 1);
                        }
                        lines[j++] = line;

                    } while (!sr.EndOfStream);
                    if (w == -1)
                    {
                        throw new Exception("Нет правильного ответа, что-то надо с этим делать");
                    }
                    q.question = lines[0];
                    q.answers = new List<string>();
                    for (x = 1; x < j; ++x)
                        q.answers.Add(lines[x]);
                    q.correctAnswers = new List<int>();
                    q.correctAnswers.Add(w);
                    questions.Add(q);
                }
                explorer.registerProjectInRuntime(project);
            }

        }
    }
}
