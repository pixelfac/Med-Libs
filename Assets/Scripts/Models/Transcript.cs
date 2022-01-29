using System.Collections.Generic;

namespace Models
{
    public class Transcript
    {
        public string acoustic_model { get; set; }
        public string audio_duration { get; set; }
        public string audio_url { get; set; }
        public string confidence { get; set; }
        public string dual_channel { get; set; }
        public bool format_text { get; set; }
        public string id { get; set; }
        public string language_model { get; set; }
        public bool punctuate { get; set; }
        public string status { get; set; }
        public string text { get; set; }
        public string utterances { get; set; }
        public string webhook_status_code { get; set; }
        public string webhook_url { get; set; }
        public IEnumerable<Word> words { get; set; }
    }
}