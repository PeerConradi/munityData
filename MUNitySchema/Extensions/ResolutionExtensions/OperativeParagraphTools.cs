﻿using MUNity.Extensions.Conversion;
using MUNity.Models.Resolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MUNity.Extensions.ResolutionExtensions
{

    /// <summary>
    /// This set of extension methods contains logic to work with operative paragraphs and the operative section.
    /// </summary>
    public static class OperativeParagraphTools
    {
        /// <summary>
        /// Allowed operators. This list can contain Regex symbols.
        /// </summary>
        private static IEnumerable<string> OperativeParagraphOperators
        {
            get
            {
                yield return "akzeptiert";
                yield return "anerkennt";
                yield return "appelliert eindringlich";
                yield return "appelliert";
                yield return "beauftrag";
                yield return "bedauert";
                yield return "bedenkt";
                yield return "befürwortet";
                yield return "begrüßt (wärmstens)";
                yield return "behält sich vor";
                yield return "beklagt";
                yield return "bekräftigt";
                yield return "bekundet.*hocherfreut";
                yield return "bekundet";
                yield return "bemerkt";
                yield return "bestätigt";
                yield return "betont";
                yield return "betrachtet";
                yield return "billigt";
                yield return "bittet.*nachdrücklich";
                yield return "bittet";
                yield return "dankt";
                yield return "delegiert";
                yield return "drängt";
                yield return "empfiehlt dringend";
                yield return "empfiehlt";
                yield return "entschließt sich";
                yield return "erinnert an";
                yield return "erinnert";
                yield return "erkennt an";
                yield return "erklärt erneut";
                yield return "erklärt";
                yield return "ermutigt";
                yield return "ernennt";
                yield return "ersucht";
                yield return "erwägt";
                yield return "fordert.*auf";
                yield return "gratuliert";
                yield return "hebt hervor";
                yield return "hofft";
                yield return "ist sich bewusst";
                yield return "ist fest überzeugt";
                yield return "ist überzeugt";
                yield return "kommt überein";
                yield return "kommt zu dem Schluss";
                yield return "kommt zu der Überzeugung";
                yield return "legt nahe";
                yield return "legt dringend nahe";
                yield return "lobt feierlich";
                yield return "macht Gebraucht von";
                yield return "macht sich zu eigen";
                yield return "nimmt an";
                yield return "nimmt hocherfreut zur Kenntnis";
                yield return "nimmt mit Bedauern zur Kenntnis";
                yield return "nimmt zur Kenntnis";
                yield return "räumt ein";
                yield return "ruft abermals auf";
                yield return "ruft auf";
                yield return "schlägt vor";
                yield return "schließt sich an";
                yield return "setzt von neuem ein";
                yield return "setzt ein";
                yield return "stellt fest";
                yield return "unterstreicht";
                yield return "unterstützt";
                yield return "verlangt unmissverständlich";
                yield return "vermerkt";
                yield return "verpflichtet sich";
                yield return "versichert";
                yield return "verurteilt.*entschieden";
                yield return "verurteilt";
                yield return "verweist";
                yield return "wiederholt";
                yield return "weist auf die Tatsache hin";
                yield return "weist auf.*hin";
                yield return "würdigt";
                yield return "zieht ernsthaft in Erwägung";
                yield return "zieht in Erwägung";

                // Sicherheitsrat Operatoren
                yield return "autorisiert";
                yield return "beschließt";
                yield return "entsendet";
                yield return "verabschiedet";
                yield return "verschärft";
            }
        }

        /// <summary>
        /// Creates a new Operative paragraph inside a given OperativeSection.
        /// </summary>
        /// <param name="section"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static OperativeParagraph CreateOperativeParagraph(this OperativeSection section, string text = "")
        {
            var paragraph = new OperativeParagraph
            {
                Text = text
            };
            section.Paragraphs.Add(paragraph);
            return paragraph;
        }

        /// <summary>
        /// Creates a new Child paragraph in a given Resolution.
        /// </summary>
        /// <param name="section"></param>
        /// <param name="parentId"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static OperativeParagraph CreateChildParagraph(this OperativeSection section, string parentId, string text = "")
        {
            var parentParagraph = section.FindOperativeParagraph(parentId);
            if (parentParagraph == null)
                throw new MUNity.Exceptions.Resolution.OperativeParagraphNotFoundException();

            var newParagraph = new OperativeParagraph
            {
                Text = text
            };
            parentParagraph.Children.Add(newParagraph);
            return newParagraph;
        }

        /// <summary>
        /// Will also create a Child paragraph by calling the CreateChildParagraph function and pass the Id to it.
        /// </summary>
        /// <param name="section"></param>
        /// <param name="parent"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static OperativeParagraph CreateChildParagraph(this OperativeSection section, OperativeParagraph parent, string text = "")
            => section.CreateChildParagraph(parent.OperativeParagraphId, text);

        /// <summary>
        /// Will search for an Operative Paragraph with the given id. Will return null if the paragraph was not found.
        /// </summary>
        /// <param name="section"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static OperativeParagraph FindOperativeParagraph(this OperativeSection section, string id)
        {
            return section.FirstOrDefault(n => n.OperativeParagraphId == id);
        }

        /// <summary>
        /// An internal function to go throw all operative paragraphs and their child paragraphs and get the path of the paragraph.
        /// </summary>
        /// <param name="paragraph"></param>
        /// <param name="targetId"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private static OperativeParagraph FindOperativeParagraphPathRecursive(OperativeParagraph paragraph, string targetId, List<OperativeParagraph> path)
        {
            if (paragraph.OperativeParagraphId == targetId)
            {
                path.Add(paragraph);
                return paragraph;
            }
            if (paragraph.Children != null && paragraph.Children.Any())
            {
                foreach (var child in paragraph.Children)
                {
                    var result = FindOperativeParagraphPathRecursive(child, targetId, path);
                    if (result != null)
                    {
                        path.Add(paragraph);
                        return result;
                    }

                }
            }
            return null;
        }

        /// <summary>
        /// Returns the Path of a Operative Paragraph as a List where every paragraph is an element to get to the last.
        /// For Example
        /// HeadParagraph > ChildParagraph1 > TargetParagraph.
        /// </summary>
        /// <param name="section"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<OperativeParagraph> GetOperativeParagraphPath(this OperativeSection section, string id)
        {
            var path = new List<OperativeParagraph>();
            foreach (var paragraph in section.Paragraphs)
            {
                var result = FindOperativeParagraphPathRecursive(paragraph, id, path);
                if (result != null)
                {
                    path.Reverse();
                    return path;
                }
            }
            return null;
        }

        /// <summary>
        /// Removes an Operative Paragraph from the Operative Section. Will also remove all the amendments that
        /// are targeting this paragraph.
        /// </summary>
        /// <param name="section"></param>
        /// <param name="paragraph"></param>
        public static void RemoveOperativeParagraph(this OperativeSection section, OperativeParagraph paragraph)
        {
            var path = section.GetOperativeParagraphPath(paragraph.OperativeParagraphId);
            if (!path.Any())
                throw new MUNity.Exceptions.Resolution.OperativeParagraphNotFoundException();
            if (path.Count == 1)
            {
                section.Paragraphs.Remove(paragraph);
            }
            else
            {
                path[path.Count - 1].Children.Remove(paragraph);
            }

            // TODO: Remove all Amendments of this paragraph and all its child paragraphs!
            foreach (var amendment in section.AddAmendments.Where(n => n.TargetSectionId == paragraph.OperativeParagraphId))
            {
                section.RemoveAmendment(amendment);
            }
        }

        /// <summary>
        /// Will return a list of suple with all information about the operative paragraphs.
        /// </summary>
        /// <param name="resolution"></param>
        /// <returns></returns>
        public static List<(string id, string path, string text)> GetRealOperativeParagraphsInfo(this Resolution resolution)
        {
            var list = new List<(string id, string path, string text)>();
            var realParagraphs = resolution.OperativeSection.Paragraphs.Where(n => !n.IsVirtual);
            int index = 1;
            foreach (var paragraph in realParagraphs)
            {
                string prePath = index.ToString();
                AddRealOperativeParagraphInfoRec(prePath, paragraph, list);
                index++;
            }
            return list;
        }

        /// <summary>
        /// Recursive function used by GetRealOperativeParagraphsInfo
        /// </summary>
        /// <param name="prePath"></param>
        /// <param name="paragraph"></param>
        /// <param name="list"></param>
        private static void AddRealOperativeParagraphInfoRec(string prePath, OperativeParagraph paragraph, List<(string id, string path, string text)> list)
        {
            var newElement = (id: paragraph.OperativeParagraphId, path: prePath, text: paragraph.Text);
            list.Add(newElement);
            if (paragraph.Children != null && paragraph.Children.Any())
            {
                var realParagraphs = paragraph.Children.Where(n => !n.IsVirtual);
                int index = 1;
                prePath += ".";
                int level = prePath.Count(n => n == '.');
                foreach (var childParagraph in realParagraphs)
                {
                    var newPath = prePath;
                    if (level == 1 || level % 4 == 1) newPath += (index - 1).ToLetter();
                    else if (level == 2 || level % 5 == 2) newPath += (index).ToRoman().ToLower();
                    AddRealOperativeParagraphInfoRec(newPath, childParagraph, list);
                    index++;
                }
            }
        }

        /// <summary>
        /// Inserts a paragraph into the real position. The index you give here is the one that you would get by blocking all virtual paragraphs out.
        /// For example: 1, (2), (3), 4, (5) where paragraph 2,3 and 5 are virtual, then the assumption is that paragraph 2 is at index 1 (starting at zero), which is not
        /// the case. You would pass 2 to this function if you want to add a paragraph between 4 but before 5.
        /// </summary>
        /// <param name="section"></param>
        /// <param name="paragraph"></param>
        /// <param name="targetIndex"></param>
        /// <param name="parentParagraph"></param>
        /// <returns></returns>
        public static int InsertIntoRealPosition(this OperativeSection section, OperativeParagraph paragraph, int targetIndex, OperativeParagraph parentParagraph)
        {
            if (parentParagraph == null)
            {
                if (targetIndex > section.Paragraphs.Count) targetIndex = section.Paragraphs.Count;
                section.Paragraphs.Insert(targetIndex, paragraph);
            }
            else
            {
                if (section.FindOperativeParagraph(parentParagraph.OperativeParagraphId) == null)
                    throw new MUNity.Exceptions.Resolution.OperativeParagraphNotFoundException("Target parent Paragraph not found in this Resolution");

                parentParagraph.Children.Insert(targetIndex, paragraph);
            }
            return targetIndex;
        }

        /// <summary>
        /// Returns the displayed Index name of a Paragraph for example 
        /// 1, 2, 2.a, 2.a.i etc.
        /// </summary>
        /// <param name="section"></param>
        /// <param name="paragraphId"></param>
        /// <returns></returns>
        public static string GetIndexNameOfOperativeParagraph(this OperativeSection section, string paragraphId)
        {
            var path = section.GetOperativeParagraphPath(paragraphId);
            var numbers = new List<int>();
            OperativeParagraph parent = null;
            foreach (var paragraph in path)
            {
                if (parent == null)
                {
                    numbers.Add(section.Paragraphs.Where(n => !n.IsVirtual).ToList().IndexOf(paragraph));
                }
                else
                {
                    numbers.Add(parent.Children.Where(n => !n.IsVirtual).ToList().IndexOf(paragraph));
                }
                parent = paragraph;
            }
            return numbers.ToArray().ToPathname();
        }

        /// <summary>
        /// Returns the Index of a paragraph inside its parent.
        /// </summary>
        /// <param name="section"></param>
        /// <param name="paragraph"></param>
        /// <returns></returns>
        public static int IndexOfParagraph(this OperativeSection section, OperativeParagraph paragraph)
        {
            int index = section.Paragraphs.IndexOf(paragraph);
            if (index != -1) return index;
            var path = section.GetOperativeParagraphPath(paragraph.OperativeParagraphId);
            var parentElement = path[path.Count - 1];
            return parentElement.Children.IndexOf(paragraph);
        }


        /// <summary>
        /// Returns a list of all Ids of all operative paragraphs that exist.
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public static List<string> GetAllOperativeParagraphIds(this OperativeSection section)
        {
            var list = new List<string>();
            list.AddRange(section.Paragraphs.Select(n => n.OperativeParagraphId));
            foreach(var paragraph in section.Paragraphs)
            {
                AddAllChildrenRecursive(paragraph, list);
            }
            return list;
        }

        /// <summary>
        /// Will execute a Linq Where inside all operative paragraphs including Child paragraphs.
        /// </summary>
        /// <param name="operativeSection"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static List<OperativeParagraph> WhereParagraph(this OperativeSection operativeSection, Func<OperativeParagraph, bool> predicate)
        {
            var list = new List<OperativeParagraph>();
            list.AddRange(operativeSection.Paragraphs.Where(predicate));
            foreach(var paragraph in operativeSection.Paragraphs)
            {
                DeepWhere(paragraph, predicate, list);
            }
            return list;
        }

        /// <summary>
        /// needed fore WhereParagraph.
        /// </summary>
        /// <param name="parentParagraph"></param>
        /// <param name="predicate"></param>
        /// <param name="resultList"></param>
        private static void DeepWhere(OperativeParagraph parentParagraph, Func<OperativeParagraph, bool> predicate, List<OperativeParagraph> resultList)
        {
            if (parentParagraph.Children != null && parentParagraph.Children.Any())
            {
                resultList.AddRange(parentParagraph.Children.Where(predicate));
                foreach(var child in parentParagraph.Children)
                {
                    DeepWhere(child, predicate, resultList);
                }
            }
        }

        /// <summary>
        /// Will make a Linq FirstOrDefault in all operative paragraphs including child paragraphs.
        /// </summary>
        /// <param name="operativeSection"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static OperativeParagraph FirstOrDefault(this OperativeSection operativeSection, Func<OperativeParagraph, bool> predicate)
        {
            var result = operativeSection.Paragraphs.FirstOrDefault(predicate);
            if (result != null) return result;
            foreach (var s in operativeSection.Paragraphs)
            {
                result = DeepFirstOrDefault(s, predicate);
                if (result != null) return result;
            }
            return null;
        }

        /// <summary>
        /// used by FirstOrDefault
        /// </summary>
        /// <param name="paragraph"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        private static OperativeParagraph DeepFirstOrDefault(this OperativeParagraph paragraph, Func<OperativeParagraph, bool> predicate)
        {
            var result = paragraph.Children.FirstOrDefault(predicate);
            if (result != null) return result;
            foreach (var child in paragraph.Children)
            {
                return DeepFirstOrDefault(child, predicate);
            }
            return null;
        }

        /// <summary>
        /// Checks if a paragraph has a Valid Operator by checking it with the List f allowed operators.
        /// </summary>
        /// <param name="paragraph"></param>
        /// <returns></returns>
        public static bool HasValidOperator(this OperativeParagraph paragraph)
        {
            foreach (var op in OperativeParagraphOperators)
            {
                if (op.Contains(".*"))
                {
                    // Regex Match
                    if (System.Text.RegularExpressions.Regex.Match(paragraph.Text, op).Success)
                        return true;
                }
                else
                {
                    if (paragraph.Text.StartsWith("_" + op + "_") || paragraph.Text.StartsWith(op + " ") || paragraph.Text == op)
                        return true;
                }
            }

            return false;
        }

        #region function linking
        /// <summary>
        /// Gets the Index/Pathname of an operative paragraph.
        /// </summary>
        /// <param name="section"></param>
        /// <param name="paragraph"></param>
        /// <returns></returns>
        public static string GetIndexNameOfOperativeParagraph(this OperativeSection section, OperativeParagraph paragraph) => section.GetIndexNameOfOperativeParagraph(paragraph.OperativeParagraphId);
        #endregion

        #region internal
        /// <summary>
        /// Adds all children to a list to create one List of all paragraphIds.
        /// </summary>
        /// <param name="paragraph"></param>
        /// <param name="list"></param>
        private static void AddAllChildrenRecursive(OperativeParagraph paragraph, List<string> list)
        {
            if (paragraph.Children != null && paragraph.Children.Any())
            {
                list.AddRange(paragraph.Children.Select(n => n.OperativeParagraphId));
                foreach(var child in paragraph.Children)
                {
                    AddAllChildrenRecursive(child, list);
                }
            }
        }
        #endregion
    }
}
