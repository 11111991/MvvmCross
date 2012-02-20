using System.IO;
using Cirrious.MvvmCross.Interfaces.Localization;
using Cirrious.MvvmCross.Interfaces.Services;
using Cirrious.MvvmCross.Interfaces.Services.SoundEffects;
using Cirrious.MvvmCross.Localization;

namespace Cirrious.MvvmCross.WindowsPhone.Services.SoundEffects
{
    public class MvxSoundEffectObjectLoader
        : MvxBaseResourceObjectLoader<IMvxSoundEffect>
          , IMvxSoundEffectLoader
    {
        protected override IMvxSoundEffect Load(Stream stream)
        {
            var xnaSoundEffect = Microsoft.Xna.Framework.Audio.SoundEffect.FromStream(stream);
            return new MvxSoundEffect(xnaSoundEffect);
        }
    }
}