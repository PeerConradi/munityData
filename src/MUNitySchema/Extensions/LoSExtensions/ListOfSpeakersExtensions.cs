using System;
using System.Collections.Generic;
using System.Text;
using MUNitySchema.Models.ListOfSpeakers;
using System.Linq;
using static MUNitySchema.Models.ListOfSpeakers.ListOfSpeakers;

namespace MUNity.Extensions.LoSExtensions
{


    /// <summary>
    /// This Extension let you control the List of Speaker and fill it with Logic.
    /// </summary>
    public static class ListOfSpeakersExtensions
    {

        /// <summary>
        /// Sets the next speaker as current speaker and removes him/her from the list.
        /// If there is noone in the Speakers the current speaker will be set to null.
        /// This will set the speaking mode to stopped.
        /// </summary>
        /// <param name="list"></param>
        public static void NextSpeaker(this ListOfSpeakers list)
        {
            if (list.Speakers.Any())
            {
                list.CurrentSpeaker = list.Speakers.First();
                list.Speakers.Remove(list.Speakers.First());
            }
            else
            {
                list.CurrentSpeaker = null;
            }
            list.Status = EStatus.Stopped;
        }

        /// <summary>
        /// Sets the next one from the list of questions as the current Question. If there
        /// is noone in the list of questions the CurrentQuestion will bet set to zero.
        /// In either case the Mode/Status will be set to STOPPED.
        /// </summary>
        /// <param name="list"></param>
        public static void NextQuestion(this ListOfSpeakers list)
        {
            if (list.Questions.Any())
            {
                list.CurrentQuestion = list.Questions.First();
                list.Questions.Remove(list.Questions.First());
            }
            else
            {
                list.CurrentQuestion = null;
            }
            list.Status = EStatus.Stopped;
        }

        /// <summary>
        /// THis will give the Speaker the default SpeakerTime and set the Mode to speaking.
        /// </summary>
        /// <param name="list"></param>
        public static void StartSpeaker(this ListOfSpeakers list)
        {
            if (list.CurrentSpeaker != null)
            {
                list.PausedQuestionTime = list.QuestionTime;
                list.StartSpeakerTime = DateTime.Now;
                list.Status = EStatus.Speaking;
            }
            else
            {
                list.Status = EStatus.Stopped;
            }
        }

        /// <summary>
        /// This will give the Question the full QuestionTime and set the Mode to question.
        /// </summary>
        /// <param name="list"></param>
        public static void StartQuestion(this ListOfSpeakers list)
        {
            if (list.CurrentQuestion != null)
            {
                list.PausedSpeakerTime = list.SpeakerTime;
                list.StartQuestionTime = DateTime.Now;
                list.Status = EStatus.Question;
            }
            else
            {
                list.Status = EStatus.Stopped;
            }
        }

        /// <summary>
        /// This will pause the speaker time. And set the Status to Either SpeakerPaused or AnswerPaused depending on the current
        /// state of the speaker. if the speaker is not talking when this method is called it will set the Status to Stopped.
        /// </summary>
        /// <param name="list"></param>
        public static void PauseSpeaker(this ListOfSpeakers list)
        {
            list.PausedSpeakerTime = list.RemainingSpeakerTime;
            if (list.Status == EStatus.Speaking)
                list.Status = EStatus.SpeakerPaused;
            else if (list.Status == EStatus.Answer)
                list.Status = EStatus.AnswerPaused;
            else
                list.Status = EStatus.Stopped;
        }

        /// <summary>
        /// This will pause the question time. And set the status to Question Paused.
        /// If the Question is not running when this method is called it will set the Status to stopped.
        /// The PauseQuestion Time will be saved in Either case.
        /// </summary>
        /// <param name="list"></param>
        public static void PauseQuestion(this ListOfSpeakers list)
        {

            list.PausedQuestionTime = list.RemainingQuestionTime;
            if (list.Status == EStatus.Question)
                list.Status = EStatus.QuestionPaused;
            else
                list.Status = EStatus.Stopped;
        }

        /// <summary>
        /// Lets a speaker continue with the remaining time, depending if he/she is in the Speaking or Answer Mode.
        /// </summary>
        /// <param name="list"></param>
        public static void ResumeSpeaker(this ListOfSpeakers list)
        {

            if (list.CurrentSpeaker != null)
            {
                if (list.Status == EStatus.SpeakerPaused)
                    list.StartSpeakerTime = DateTime.Now.AddSeconds(list.RemainingSpeakerTime.TotalSeconds - list.SpeakerTime.TotalSeconds);
                else if (list.Status == EStatus.AnswerPaused)
                    list.StartSpeakerTime = DateTime.Now.AddSeconds(list.RemainingSpeakerTime.TotalSeconds - list.QuestionTime.TotalSeconds);
                else
                {
                    list.StartSpeakerTime = DateTime.Now;
                }

                // Fixes a small glitch in the Question time!
                list.StartQuestionTime = DateTime.Now;
                list.Status = EStatus.Speaking;
            }
            else
            {
                list.Status = EStatus.Stopped;
            }
        }

        public static void ResumeQuestion(this ListOfSpeakers list)
        {
            if (list.CurrentQuestion != null)
            {
                list.StartQuestionTime = DateTime.Now.AddSeconds(list.RemainingQuestionTime.TotalSeconds - list.QuestionTime.TotalSeconds);
                list.Status = EStatus.Question;
            }
            else
            {
                list.Status = EStatus.Stopped;
            }
        }

        public static Speaker AddSpeaker(this ListOfSpeakers list, string name, string iso = "")
        {
            var newSpeaker = new Speaker()
            {
                Id = Guid.NewGuid().ToString(),
                Iso = iso,
                Name = name
            };
            list.Speakers.Add(newSpeaker);
            return newSpeaker;
        }

        public static Speaker AddQuestion(this ListOfSpeakers list, string name, string iso = "")
        {
            var newSpeaker = new Speaker()
            {
                Id = Guid.NewGuid().ToString(),
                Iso = iso,
                Name = name
            };
            list.Questions.Add(newSpeaker);
            return newSpeaker;
        }

        public static void ClearCurrentSpeaker(this ListOfSpeakers list)
        {
            if (list.Status == EStatus.Speaking || list.Status == EStatus.SpeakerPaused || list.Status == EStatus.Answer || list.Status == EStatus.AnswerPaused)
                list.Status = EStatus.Stopped;
            list.CurrentQuestion = null;
        }

        public static void ClearCurrentQuestion(this ListOfSpeakers list)
        {
            if (list.Status == EStatus.Question || list.Status == EStatus.QuestionPaused)
                list.Status = EStatus.Stopped;
            list.CurrentQuestion = null;
        }

        public static void AddSpeakerSeconds(this ListOfSpeakers list, int seconds)
        {
            list.StartSpeakerTime = list.StartSpeakerTime.AddSeconds(seconds);
        }

        public static void AddQuestionSeconds(this ListOfSpeakers list, int seconds)
        {
            list.StartSpeakerTime = list.StartQuestionTime.AddSeconds(seconds);
        }
    }
}
