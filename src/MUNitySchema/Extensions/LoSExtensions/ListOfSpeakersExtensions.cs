using System;
using System.Collections.Generic;
using System.Text;
using MUNitySchema.Models.ListOfSpeakers;
using System.Linq;
using static MUNitySchema.Models.ListOfSpeakers.ListOfSpeakers;

namespace MUNity.Extensions.LoSExtensions
{
    public static class ListOfSpeakersExtensions
    {
        public static void NextSpeaker(this ListOfSpeakers list)
        {
            if (list.Speakers.Any())
            {
                list.CurrentSpeaker = list.Speakers.First();
                list.Speakers.Remove(list.Speakers.First());
            }
            list.Status = EStatus.Stopped;
        }

        public static void NextQuestion(this ListOfSpeakers list)
        {
            if (list.Questions.Any())
            {
                list.CurrentQuestion = list.Questions.First();
                list.Questions.Remove(list.Questions.First());
            }
            list.Status = EStatus.Stopped;
        }

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

        public static void PauseQuestion(this ListOfSpeakers list)
        {
            list.PausedQuestionTime = list.RemainingQuestionTime;
            list.Status = EStatus.QuestionPaused;
        }

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
