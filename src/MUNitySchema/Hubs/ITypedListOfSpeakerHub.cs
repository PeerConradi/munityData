using MUNitySchema.Models.ListOfSpeakers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MUNitySchema.Hubs
{
    public interface ITypedListOfSpeakerHub
    {
        Task SpeakerListChanged(ListOfSpeakers listOfSpeaker);

        Task SpeakerTimerStarted(int seconds);

        Task QuestionTimerStarted(int seconds);

        Task TimerStopped();

        Task SpeakerTimerSynced(int seconds);
    }
}
