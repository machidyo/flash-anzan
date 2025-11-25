using Newtonsoft.Json;
using R3;

namespace FlashAnzan.Domain.Setting.Model
{
    public class Setting
    {
        [JsonProperty("Grade")]
        public int Grade { get; private set; } 
        
        [JsonIgnore]
        public Observable<ValueChangedEvent> OnValueChanged => subject;
        private readonly Subject<ValueChangedEvent> subject =  new ();

        // private setの問題とその動作確認から
        public Setting(int grade)
        {
            Grade = grade;
        }
        
        public void SetGrade(int grade)
        {
            Grade = grade;
            subject.OnNext(new ValueChangedEvent(grade));
        }
                
        public readonly struct ValueChangedEvent
        {
            public int Grade { get; }
            
            public ValueChangedEvent(int grade)
            {
                Grade = grade;
            }
        }
    }
}
