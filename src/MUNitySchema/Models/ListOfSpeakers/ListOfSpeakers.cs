using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MUNitySchema.Models.ListOfSpeakers
{
    public class ListOfSpeakers
    {
        public enum EStatus
        {
            Stopped,
            Speaking,
            Question,
            Answer,
            SpeakerPaused,
            QuestionPaused,
            AnswerPaused
        }

        public string ListOfSpeakersId { get; set; }

        public string PublicId { get; set; }

        public string Name { get; set; }

        public EStatus Status { get; set; }

        public TimeSpan SpeakerTime { get; set; }

        public TimeSpan QuestionTime { get; set; }

        public TimeSpan PausedSpeakerTime { get; set; }

        public TimeSpan PausedQuestionTime { get; set; }

        public TimeSpan RemainingSpeakerTime
        {
            get
            {
                if (Status == EStatus.Stopped || Status == EStatus.Question || Status == EStatus.SpeakerPaused || Status == EStatus.QuestionPaused)
                {
                    return PausedSpeakerTime;
                }
                else if (Status == EStatus.Speaking)
                {
                    var finishTime = StartSpeakerTime.AddSeconds(SpeakerTime.TotalSeconds);
                    return finishTime - DateTime.Now;
                    // Startzeitpunkt                 Startzeitpunkt + Speakertime
                    //       |---------------|<-------->|
                    //                          Verbleibende Zeit
                }

                // Fall für das Fortsetzen eienr Antwort!
                var finishTimeQuestion = StartSpeakerTime.AddSeconds(QuestionTime.TotalSeconds);
                return finishTimeQuestion - DateTime.Now;
            }
        }

        public TimeSpan RemainingQuestionTime
        {
            get
            {
                if (Status != EStatus.Question && Status != EStatus.QuestionPaused) return PausedQuestionTime;

                var finishTime = StartQuestionTime.AddSeconds(QuestionTime.TotalSeconds);
                return finishTime - DateTime.Now;
            }
        }

        public ObservableCollection<Speaker> Speakers { get; set; } = new ObservableCollection<Speaker>();

        public ObservableCollection<Speaker> Questions { get; set; } = new ObservableCollection<Speaker>();

        public Speaker CurrentSpeaker { get; set; }

        public Speaker CurrentQuestion { get; set; }


        public bool ListClosed { get; set; } = false;

        public bool QuestionsClosed { get; set; } = false;

        public TimeSpan LowTimeMark { get; set; }

        public DateTime StartSpeakerTime { get; set; }

        public DateTime StartQuestionTime { get; set; }
    }
}
