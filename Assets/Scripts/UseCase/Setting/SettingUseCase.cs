using Cysharp.Threading.Tasks;
using FlashAnzan.Setting.Repository;
using SettingModel = FlashAnzan.Domain.Setting.Model.Setting;

namespace FlashAnzan.UseCase.Setting
{
    public class SettingUseCase
    {
        public SettingModel Model { get; private set; }
        
        private readonly SettingRepository settingRepository;

        public SettingUseCase(SettingModel model, SettingRepository settingRepository)
        {
            Model = model;
            this.settingRepository = settingRepository;
            FetchSettingAsync().Forget();
        }

        public async UniTask FetchSettingAsync()
        {
            Model = await settingRepository.FetchSettingAsync();
        }

        public async UniTask SaveGrade(int grade)
        {
            Model.SetGrade(grade);
            await settingRepository.SaveSettingAsync(Model);
        }
    }
}
