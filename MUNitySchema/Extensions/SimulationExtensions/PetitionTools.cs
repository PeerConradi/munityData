using System;
using System.Collections.Generic;
using System.Text;

namespace MUNity.Extensions.SimulationExtensions
{
    /// <summary>
    /// Gives a libary of functions for the Simulation.
    /// </summary>
    public static class PetitionTools
    {
        public enum EPetitionCategory
        {
            Personal,
            RuleOfProcedure,
            Unknown
        }

        /// <summary>
        /// Returns the Display Text of the given Petition type.
        /// For now this will return the text in german, other languages will be supported in future releases.
        /// </summary>
        /// <param name="type">The type of petition</param>
        /// <returns></returns>
        public static string DisplayText(this MUNity.Schema.Simulation.Petition.PetitionTypes type)
        {
            switch (type)
            {
                case MUNity.Schema.Simulation.Petition.PetitionTypes.PersRechtAufInformation:
                    return "Recht auf Information";
                case MUNity.Schema.Simulation.Petition.PetitionTypes.PersRechtAufOrdnung:
                    return "Recht auf Wiederherstellung der Ordnung";
                case MUNity.Schema.Simulation.Petition.PetitionTypes.PersRechtAufKlaerung:
                    return "Recht auf Klärung eines Missverständnisses";
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOMuendlicheAbstimmung:
                    return "mündliche Abstimmung";
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GORevision:
                    return "Revision einer Entscheidung des Vorsitzes";
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOInformelleSitzung:
                    return "informelle Sitzung";
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GONeuTagesordnungspunkt:
                    return "Aufnahme eines neuen Tagesordnungspunktes";
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOZurueckResolutionsentwurf:
                    return "Zurückschicken eines Resolutionsentwurfes";
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOVertagung:
                    return "Vertagung eines Tagesordnungspunktes";
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GORueckAllgDebatte:
                    return "Rückkehr zur Allgemeinen Debatte";
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOEndeDebatte:
                    return "Ende der aktuellen Debatte";
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOVorgezogenAbstReso:
                    return "Vorgezogene Abstimmung über den Resolutionsentwurf als Ganzes";
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOAbschlussRedeliste:
                    return "Abschluss oder Wiedereröffnung der Redeliste";
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOAendereRedezeit:
                    return "Änderung der Redezeit";
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOGastredner:
                    return "Anhörung eines Gastredners";
                default:
                    return type.ToString();
            }
        }

        public static EPetitionCategory Category(this MUNity.Schema.Simulation.Petition.PetitionTypes type)
        {
            switch (type)
            {
                case MUNity.Schema.Simulation.Petition.PetitionTypes.PersRechtAufInformation:
                case MUNity.Schema.Simulation.Petition.PetitionTypes.PersRechtAufOrdnung:
                case MUNity.Schema.Simulation.Petition.PetitionTypes.PersRechtAufKlaerung:
                    return EPetitionCategory.Personal;
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOMuendlicheAbstimmung:
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GORevision:
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOInformelleSitzung:
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GONeuTagesordnungspunkt:
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOZurueckResolutionsentwurf:
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOVertagung:
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GORueckAllgDebatte:
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOEndeDebatte:
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOVorgezogenAbstReso:
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOAbschlussRedeliste:
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOAendereRedezeit:
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOGastredner:
                    return EPetitionCategory.RuleOfProcedure;
                default:
                    return EPetitionCategory.Unknown;
            }
        }

        /// <summary>
        /// Returns the type of ruling given by the dmun Model United Nations conferences.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static MUNity.Schema.Simulation.Petition.PetitionRulings Ruling(this MUNity.Schema.Simulation.Petition.PetitionTypes type)
        {
            switch (type)
            {
                case MUNity.Schema.Simulation.Petition.PetitionTypes.PersRechtAufInformation:
                case MUNity.Schema.Simulation.Petition.PetitionTypes.PersRechtAufOrdnung:
                case MUNity.Schema.Simulation.Petition.PetitionTypes.PersRechtAufKlaerung:
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOMuendlicheAbstimmung:
                    return MUNity.Schema.Simulation.Petition.PetitionRulings.Chairs;
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GORevision:
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GORueckAllgDebatte:
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOEndeDebatte:
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOVorgezogenAbstReso:
                    return MUNity.Schema.Simulation.Petition.PetitionRulings.TwoThirds;
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOInformelleSitzung:
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOZurueckResolutionsentwurf:
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOVertagung:
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOAbschlussRedeliste:
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOAendereRedezeit:
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOGastredner:
                    return MUNity.Schema.Simulation.Petition.PetitionRulings.simpleMajority;
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GONeuTagesordnungspunkt:
                    return MUNity.Schema.Simulation.Petition.PetitionRulings.TwoThirdsPlusPermanentMembers;
                default:
                    return MUNity.Schema.Simulation.Petition.PetitionRulings.Unknown;
            }
        }

        public static string Explanation(this MUNity.Schema.Simulation.Petition.PetitionTypes type)
        {
            switch (type)
            {
                case MUNity.Schema.Simulation.Petition.PetitionTypes.PersRechtAufInformation:
                    return "Für Fragen zur Geschäftsordnung oder zum Verfahren (z.B.zu Anträgen, Einreichen von Arbeitspapieren). Außerdem für Bitten(z.B.Fenster öffnen, Licht einschalten, lauter sprechen).";
                case MUNity.Schema.Simulation.Petition.PetitionTypes.PersRechtAufOrdnung:
                    return "Um Verfahrensfehler oder Verstöße gegen die Geschäftsordnung zur Sprache zu bringen.";
                case MUNity.Schema.Simulation.Petition.PetitionTypes.PersRechtAufKlaerung:
                    return "Nur nach einer Erwiderung vom Redner auf eine eigene missverstandene und unbeantwortet gelassene Frage oder Kurzbemerkung möglich.";
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOMuendlicheAbstimmung:
                    return "Abstimmung, bei der die Staaten in alphabetischer Reihenfolge aufgerufen werden und ihre Stimme verkünden. Nur bei knappen oder unklaren Ergebnissen möglich.";
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GORevision:
                    return "Entscheidungen des Vorsitzes können vorbehaltlich anderer Regelungen revidiert werden. Vor der Abstimmung soll der Vorsitz seine Entscheidung begründen.";
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOInformelleSitzung:
                    return "Der Vorsitz kann über diesen Antrag entscheiden.";
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GONeuTagesordnungspunkt:
                    return "Der neue Tagesordnungspunkt wird unmittelbar behandelt. Der aktuelle Tagesordnungspunkt wird automatisch zum nächsten Tagesordnungspunkt.";
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOZurueckResolutionsentwurf:
                    return "Der Antragsteller erklärt, welche Punkte beim verabschiedeten Resolutionsentwurf geändert werden sollen. Es können mehrere Anträge dieser Art angenommen werden.";
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOVertagung:
                    return "Der aktuelle Tagesordnungspunkt wird an das Ende der Tagesordnung verschoben. Der Antragssteller muss denjenigen Tagesordnungspunkt nennen, mit dem das Gremium als nächstes fortfahren soll.";
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GORueckAllgDebatte:
                    return "Es verfallen alle Resolutionsentwürfe und Änderungsanträge und die Allgemeine Debatte beginnt von Neuem.";
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOEndeDebatte:
                    return "Die aktuelle Debatte wird sofort beendet und mit dem nächsten Verfahrensbestandteil fortgefahren.";
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOVorgezogenAbstReso:
                    return "Sofortige Abstimmung über den Resolutionsentwurf in seiner jetzigen Form. Es werden weder die ausstehenden Änderungsanträge behandelt noch erfolgt eine Abstimmung über die einzelnen operativen Absätze.";
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOAbschlussRedeliste:
                    return "Bezieht sich entweder auf die Redeliste für Redebeiträge oder auf die Redeliste für Fragen und Kurzbemerkungen. Der Vorsitz kann über diesen Antrag entscheiden.";
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOAendereRedezeit:
                    return "Der Antrag kann sich sowohl auf die Redezeit für Redebeiträge als auch für Fragen und Kurzbemerkungen beziehen. Der Vorsitz kann über diesen Antrag entscheiden.";
                case MUNity.Schema.Simulation.Petition.PetitionTypes.GOGastredner:
                    return "Nur zum aktuellen Tagesordnungspunkt möglich.";
                default:
                    return "Keine Erkärung vorhanden.";
            }
        }
    }
}
