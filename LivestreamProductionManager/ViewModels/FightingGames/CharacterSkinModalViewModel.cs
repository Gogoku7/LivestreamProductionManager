using LivestreamProductionManager.Models.FightingGames.Skins;
using System;
using System.Collections.Generic;

namespace LivestreamProductionManager.ViewModels.FightingGames
{
    public class CharacterSkinModalViewModel
    {
        public bool Success { get; set; }
        public bool SupportsSkins { get; set; }
        public string CharacterDropdownSelector { get; set; }
        public string CharacterSkinPickerToggleSelector { get; set; }
        public string CharacterSkinPickerSelector { get; set; }
        public List<Skin> CharacterSkins { get; set; }
        public string SelectedCharacterSkin { get; set; }

        public CharacterSkinModalViewModel()
        {

        }

        public CharacterSkinModalViewModel(bool supportsSkins, List<Skin> characterSkins)
        {
            SupportsSkins = supportsSkins;
            CharacterSkins = characterSkins;
        }

        public IEnumerable<List<Skin>> SplitCharacterSkins(int splitBy = 4)
        {
            for (int i = 0; i < CharacterSkins.Count; i += splitBy)
            {
                yield return CharacterSkins.GetRange(i, Math.Min(splitBy, CharacterSkins.Count - i));
            }
        }
    }
}