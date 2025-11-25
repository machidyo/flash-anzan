using Cysharp.Threading.Tasks;
using UnityEngine;
using TMPro;
using R3;
using FlashAnzan.PresentationFramework;

namespace FlashAnzan.View.Setting
{
    public class SettingValuesView : AppView<SettingValuesViewState>
    {
        [SerializeField] private TextMeshProUGUI gradeText;

        protected override UniTask Initialize(SettingValuesViewState state)
        {
            state.Grade
                .DistinctUntilChanged()
                .Subscribe(grade => gradeText.text = $"Setting Modal(GRADE: {grade})")
                .AddTo(this);
            return UniTask.CompletedTask;
        }
    }
}