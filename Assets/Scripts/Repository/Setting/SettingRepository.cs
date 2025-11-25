using Cysharp.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;
using SettingModel = FlashAnzan.Domain.Setting.Model.Setting;

namespace FlashAnzan.Setting.Repository
{
    public class SettingRepository
    {
        private const string SETTING = "Setting";

        public async UniTask<SettingModel> FetchSettingAsync()
        {
            var json = PlayerPrefs.GetString(SETTING);
            if (string.IsNullOrEmpty(json))
            {
                return await Init();
            }
            else
            {
                return JsonConvert.DeserializeObject<SettingModel>(json);
            }
        }
        
        public async UniTask SaveSettingAsync(SettingModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            PlayerPrefs.SetString(SETTING, json);
            await UniTask.CompletedTask;
        }

        private async UniTask<SettingModel> Init()
        {
            var model = new SettingModel(1);
            await SaveSettingAsync(model);
            return model;
        }
    }
}