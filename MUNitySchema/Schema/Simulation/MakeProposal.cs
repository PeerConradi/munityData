using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUNity.Schema.Simulation
{
    public class MakeProposal : SimulationRequest
    {
        /// <summary>
        /// ProposalTypes will be reworked for other conferences that are not dmun conferences.
        /// For now you make this working with DMUN Conferences MUN-SH and MUNBW
        /// </summary>
        public enum ProposalTypes
        {
            /// <summary>
            /// Persönlicher Antrag für Recht auf Information. Kann nurch NA gestellt werden
            /// </summary>
            PersRechtAufInformation,
            /// <summary>
            /// REcht auf Wiederherstellung der Ordnung, dieser Antrag kann durch NAs gestellt werden.
            /// </summary>
            PersRechtAufOrdnung,
            /// <summary>
            /// Recht auf Klärung eines Missverständnisses. Dieser Antrag kann durch NAs gestellt werden.
            /// </summary>
            PersRechtAufKlaerung,
            /// <summary>
            /// Geschäftsordnungantrag auf Mündliche Abstimmung, Dieser Antrag kann durch NAs gestellt werden
            /// </summary>
            GOMuendlicheAbstimmung,
            /// <summary>
            /// GEschäftsordnungsantrag auf Revision einer Entscheidung des Vorsitzes. Kann nicht durch NAs gestellt werden.
            /// </summary>
            GORevision,
            /// <summary>
            /// Geschäftsordnungsantrag informelle Sitzung kann auch durch NAs gestellt werden.
            /// </summary>
            GOInformelleSitzung,
            /// <summary>
            /// Geschäftsordnungsantrag Aufname eines neuen Tagesordnungspunktes. Nicht nurch NAs und nur im Sicherheitsrat.
            /// </summary>
            GONeuTagesordnungspunkt,
            /// <summary>
            /// Antrag auf zurückschicken eiens Resolutionsentwurfs. Nicht durch NAs, Begürdungs- und Gegenrede
            /// </summary>
            GOZurueckResolutionsentwurf,
            GOVertagung,
            GORueckAllgDebatte,
            GOEndeDebatte,
            GOVorgezogenAbstReso,
            GOAbschlussRedeliste,
            GOAendereRedezeit,
            GOGastredner
        }

        [Required]
        public ProposalTypes ProposalType { get; set; }

        public string Text { get; set; }
    }
}
