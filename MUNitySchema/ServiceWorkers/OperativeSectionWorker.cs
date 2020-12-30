using System;
using System.Collections.Generic;
using System.Text;
using MUNity.Models.Resolution;
using System.Linq;

namespace MUNity.ServiceWorkers
{
    public class OperativeSectionWorker : IDisposable
    {
        private ResolutionWorker _resolutionWorker;

        private OperativeSection _operativeSection;

        private OperativeSectionWorker(ResolutionWorker resoluionWorker, OperativeSection operativeSection)
        {
            this._resolutionWorker = resoluionWorker;
            this._operativeSection = operativeSection;
            _resolutionWorker.RegisterOperativeSectionWorker(this);
            AppendOperativeSectionEvents(operativeSection);
        }

        private void AppendOperativeSectionEvents(OperativeSection section)
        {
            _operativeSection.Paragraphs.CollectionChanged += Paragraphs_CollectionChanged;
            foreach (var op in _operativeSection.Paragraphs)
            {
                OperativeParagraphWorker.CreateWorker(this, op);
            }
        }

        private void Paragraphs_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach(var newParagraph in e.NewItems.OfType<OperativeParagraph>())
                {
                    OperativeParagraphWorker.CreateWorker(this, newParagraph);
                }
            }

            this._resolutionWorker.InvokeOperativeSectionChanged();
        }

        public void InvokeParagraphChanged(OperativeParagraph paragraph)
        {
            this._resolutionWorker.InvokeOperativeParagraphChanged(paragraph);
        }

        public static OperativeSectionWorker CreateWorker(ResolutionWorker resolutionWorker, OperativeSection operativeSection)
        {
            return new OperativeSectionWorker(resolutionWorker, operativeSection);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
