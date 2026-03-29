using Godot;
using System;
using System.Collections.Generic;
using Godot.Collections;

public partial class Sphere : Sprite2D
{
    public Array<Sphere> ConnectedSpheres { get; set; }
    private int _lastConnectedCount;
    
    public event EventHandler OnConnectedSpheresChanged;

    public void SetData(SphereData sphereData)
    {
        Scale = sphereData.Type switch
        {
            (int)Enums.SphereType.Minor => new Vector2(0.25f, 0.25f),
            (int)Enums.SphereType.Major => new Vector2(0.5f, 0.5f),
            (int)Enums.SphereType.Key => new Vector2(1f, 1f),
            _ => Scale
        };

        if (sphereData.FighterCards.Count > 0)
            Texture = GlobalData.Instance.SphereIcons[30];
        else if (sphereData.Spells.Count > 0)
            Texture = GlobalData.Instance.SphereIcons[31];
        else if (sphereData.Effects.Count > 0)
            Texture = GetTextureFromEffects(sphereData.Effects);
        else
            Texture = GlobalData.Instance.SphereIcons[32];
    }

    private Color GetColor(List<EffectData> effects)
    {
        return Colors.White;
    }
    
    private Texture2D GetTextureFromEffects(List<EffectData> effects)
    {
        return (Enums.ActionType)effects[0].ActionId switch
        {
            Enums.ActionType.BreedFireDamage => GlobalData.Instance.SphereIcons[5],
            Enums.ActionType.BreedEarthDamage => GlobalData.Instance.SphereIcons[6],
            Enums.ActionType.BreedWaterDamage => GlobalData.Instance.SphereIcons[7],
            Enums.ActionType.BreedWindDamage => GlobalData.Instance.SphereIcons[4],
            Enums.ActionType.DefaultHpLoss => GlobalData.Instance.SphereIcons[24],
            Enums.ActionType.WeaponFireDamage => GlobalData.Instance.SphereIcons[5],
            Enums.ActionType.WeaponEarthDamage => GlobalData.Instance.SphereIcons[6],
            Enums.ActionType.WeaponWaterDamage => GlobalData.Instance.SphereIcons[7],
            Enums.ActionType.WeaponWindDamage => GlobalData.Instance.SphereIcons[4],
            Enums.ActionType.SpellPhysicalDamage => GlobalData.Instance.SphereIcons[24],
            Enums.ActionType.SpellFireDamage => GlobalData.Instance.SphereIcons[5],
            Enums.ActionType.SpellEarthDamage => GlobalData.Instance.SphereIcons[6],
            Enums.ActionType.SpellWaterDamage => GlobalData.Instance.SphereIcons[7],
            Enums.ActionType.SpellWindDamage => GlobalData.Instance.SphereIcons[4],
            Enums.ActionType.SpellFireDamagePerApRemaining => GlobalData.Instance.SphereIcons[5],
            Enums.ActionType.SpellFireDamagePerMpRemaining => GlobalData.Instance.SphereIcons[5],
            Enums.ActionType.SpellWindDamagePerApRemaining => GlobalData.Instance.SphereIcons[4],
            Enums.ActionType.SpellWindDamagePerMpRemaining => GlobalData.Instance.SphereIcons[4],
            Enums.ActionType.SpellWaterDamagePerApRemaining => GlobalData.Instance.SphereIcons[7],
            Enums.ActionType.SpellWaterDamagePerMpRemaining => GlobalData.Instance.SphereIcons[7],
            Enums.ActionType.SpellEarthDamagePerApRemaining => GlobalData.Instance.SphereIcons[6],
            Enums.ActionType.SpellEarthDamagePerMpRemaining => GlobalData.Instance.SphereIcons[6],
            Enums.ActionType.SpellFireDamageAreaTrigger => GlobalData.Instance.SphereIcons[5],
            Enums.ActionType.SpellWaterDamageAreaTrigger => GlobalData.Instance.SphereIcons[7],
            Enums.ActionType.SpellWindDamageAreaTrigger => GlobalData.Instance.SphereIcons[4],
            Enums.ActionType.SpellEarthDamageAreaTrigger => GlobalData.Instance.SphereIcons[6],
            Enums.ActionType.ApLossAreaTrigger => GlobalData.Instance.SphereIcons[15],
            Enums.ActionType.MpLossAreaTrigger => GlobalData.Instance.SphereIcons[16],
            Enums.ActionType.HpLeech => GlobalData.Instance.SphereIcons[24],
            Enums.ActionType.HpLeechFire => GlobalData.Instance.SphereIcons[5],
            Enums.ActionType.HpLeechEarth => GlobalData.Instance.SphereIcons[6],
            Enums.ActionType.HpLeechWater => GlobalData.Instance.SphereIcons[7],
            Enums.ActionType.HpLeechWind => GlobalData.Instance.SphereIcons[4],
            Enums.ActionType.DamagePercent => GlobalData.Instance.SphereIcons[24],
            Enums.ActionType.Poison => GlobalData.Instance.SphereIcons[24],
            Enums.ActionType.Heal => GlobalData.Instance.SphereIcons[21],
            Enums.ActionType.UseAp => GlobalData.Instance.SphereIcons[15],
            Enums.ActionType.UseMp => GlobalData.Instance.SphereIcons[16],
            Enums.ActionType.CharacteristicBoostHp => GlobalData.Instance.SphereIcons[18],
            Enums.ActionType.CharacteristicDeboostHp => GlobalData.Instance.SphereIcons[18],
            Enums.ActionType.CharacteristicBoostAp => GlobalData.Instance.SphereIcons[15],
            Enums.ActionType.CharacteristicBoostAp2 => GlobalData.Instance.SphereIcons[15],
            Enums.ActionType.CharacteristicDeboostAp => GlobalData.Instance.SphereIcons[15],
            Enums.ActionType.CharacteristicDeboostAp2 => GlobalData.Instance.SphereIcons[15],
            Enums.ActionType.CharacteristicBoostMp => GlobalData.Instance.SphereIcons[16],
            Enums.ActionType.CharacteristicBoostMp2 => GlobalData.Instance.SphereIcons[16],
            Enums.ActionType.CharacteristicDeboostMp => GlobalData.Instance.SphereIcons[16],
            Enums.ActionType.CharacteristicDeboostMp2 => GlobalData.Instance.SphereIcons[16],
            Enums.ActionType.CharacteristicGainAp => GlobalData.Instance.SphereIcons[15],
            Enums.ActionType.CharacteristicGainMp => GlobalData.Instance.SphereIcons[16],
            Enums.ActionType.CharacteristicGainResFlatFire => GlobalData.Instance.SphereIcons[5],
            Enums.ActionType.CharacteristicGainResFlatEarth => GlobalData.Instance.SphereIcons[6],
            Enums.ActionType.CharacteristicGainResFlatWater => GlobalData.Instance.SphereIcons[7],
            Enums.ActionType.CharacteristicGainResFlatWind => GlobalData.Instance.SphereIcons[4],
            Enums.ActionType.CharacteristicGainResPercentFire => GlobalData.Instance.SphereIcons[10],
            Enums.ActionType.CharacteristicGainResPercentEarth => GlobalData.Instance.SphereIcons[11],
            Enums.ActionType.CharacteristicGainResPercentWater => GlobalData.Instance.SphereIcons[12],
            Enums.ActionType.CharacteristicGainResPercentWind => GlobalData.Instance.SphereIcons[9],
            Enums.ActionType.CharacteristicGainResPercentAll => GlobalData.Instance.SphereIcons[13],
            Enums.ActionType.CharacteristicGainResArea => GlobalData.Instance.SphereIcons[13],
            Enums.ActionType.CharacteristicGainDmgFlatFire => GlobalData.Instance.SphereIcons[5],
            Enums.ActionType.CharacteristicGainDmgFlatEarth => GlobalData.Instance.SphereIcons[6],
            Enums.ActionType.CharacteristicGainDmgFlatWater => GlobalData.Instance.SphereIcons[7],
            Enums.ActionType.CharacteristicGainDmgFlatWind => GlobalData.Instance.SphereIcons[4],
            Enums.ActionType.CharacteristicGainDmgPercentFire => GlobalData.Instance.SphereIcons[5],
            Enums.ActionType.CharacteristicGainDmgPercentEarth => GlobalData.Instance.SphereIcons[6],
            Enums.ActionType.CharacteristicGainDmgPercentWater => GlobalData.Instance.SphereIcons[7],
            Enums.ActionType.CharacteristicGainDmgPercentWind => GlobalData.Instance.SphereIcons[4],
            Enums.ActionType.CharacteristicGainDmgPercentAll => GlobalData.Instance.SphereIcons[8],
            Enums.ActionType.CharacteristicGainCc => GlobalData.Instance.SphereIcons[3],
            Enums.ActionType.CharacteristicGainEc => GlobalData.Instance.SphereIcons[3],
            Enums.ActionType.CharacteristicGainRange => GlobalData.Instance.SphereIcons[19],
            Enums.ActionType.CharacteristicGainInit => GlobalData.Instance.SphereIcons[17],
            Enums.ActionType.CharacteristicGainHeal => GlobalData.Instance.SphereIcons[21],
            Enums.ActionType.CharacteristicGainResApDebuff => GlobalData.Instance.SphereIcons[15],
            Enums.ActionType.CharacteristicGainResMpDebuff => GlobalData.Instance.SphereIcons[16],
            Enums.ActionType.CharacteristicGainDamagesReboundPercent => GlobalData.Instance.SphereIcons[20],
            Enums.ActionType.CharacteristicGainTackle => GlobalData.Instance.SphereIcons[1],
            Enums.ActionType.CharacteristicGainDodge => GlobalData.Instance.SphereIcons[2],
            Enums.ActionType.CharacteristicGainSummonNumber => GlobalData.Instance.SphereIcons[14],
            Enums.ActionType.CharacteristicGainSummonDmg => GlobalData.Instance.SphereIcons[14],
            Enums.ActionType.CharacteristicGainSummonRes => GlobalData.Instance.SphereIcons[14],
            Enums.ActionType.CharacteristicGainSummonCc => GlobalData.Instance.SphereIcons[14],
            Enums.ActionType.CharacteristicGainSummonTackle => GlobalData.Instance.SphereIcons[14],
            Enums.ActionType.CharacteristicGainSummonHp => GlobalData.Instance.SphereIcons[14],
            Enums.ActionType.CharacteristicLossAp => GlobalData.Instance.SphereIcons[15],
            Enums.ActionType.CharacteristicLossMp => GlobalData.Instance.SphereIcons[16],
            Enums.ActionType.CharacteristicLossResFlatFire => GlobalData.Instance.SphereIcons[10],
            Enums.ActionType.CharacteristicLossResFlatEarth => GlobalData.Instance.SphereIcons[11],
            Enums.ActionType.CharacteristicLossResFlatWater => GlobalData.Instance.SphereIcons[12],
            Enums.ActionType.CharacteristicLossResFlatWind => GlobalData.Instance.SphereIcons[9],
            Enums.ActionType.CharacteristicLossResPercentFire => GlobalData.Instance.SphereIcons[10],
            Enums.ActionType.CharacteristicLossResPercentEarth => GlobalData.Instance.SphereIcons[11],
            Enums.ActionType.CharacteristicLossResPercentWater => GlobalData.Instance.SphereIcons[12],
            Enums.ActionType.CharacteristicLossResPercentWind => GlobalData.Instance.SphereIcons[9],
            Enums.ActionType.CharacteristicLossResPercentAll => GlobalData.Instance.SphereIcons[13],
            Enums.ActionType.CharacteristicLossResArea => GlobalData.Instance.SphereIcons[13],
            Enums.ActionType.CharacteristicLossDmgFlatFire => GlobalData.Instance.SphereIcons[5],
            Enums.ActionType.CharacteristicLossDmgFlatEarth => GlobalData.Instance.SphereIcons[6],
            Enums.ActionType.CharacteristicLossDmgFlatWater => GlobalData.Instance.SphereIcons[7],
            Enums.ActionType.CharacteristicLossDmgFlatWind => GlobalData.Instance.SphereIcons[4],
            Enums.ActionType.CharacteristicLossDmgPercentFire => GlobalData.Instance.SphereIcons[5],
            Enums.ActionType.CharacteristicLossDmgPercentEarth => GlobalData.Instance.SphereIcons[6],
            Enums.ActionType.CharacteristicLossDmgPercentWater => GlobalData.Instance.SphereIcons[7],
            Enums.ActionType.CharacteristicLossDmgPercentWind => GlobalData.Instance.SphereIcons[4],
            Enums.ActionType.CharacteristicLossDmgPercentAll => GlobalData.Instance.SphereIcons[8],
            Enums.ActionType.CharacteristicLossCc => GlobalData.Instance.SphereIcons[3],
            Enums.ActionType.CharacteristicLossEc => GlobalData.Instance.SphereIcons[3],
            Enums.ActionType.CharacteristicLossRange => GlobalData.Instance.SphereIcons[19],
            Enums.ActionType.CharacteristicLossInit => GlobalData.Instance.SphereIcons[17],
            Enums.ActionType.CharacteristicLossHeal => GlobalData.Instance.SphereIcons[21],
            Enums.ActionType.CharacteristicLossTackle => GlobalData.Instance.SphereIcons[1],
            Enums.ActionType.CharacteristicLossDodge => GlobalData.Instance.SphereIcons[2],
            Enums.ActionType.CharacteristicLeechAp => GlobalData.Instance.SphereIcons[15],
            Enums.ActionType.CharacteristicLeechMp => GlobalData.Instance.SphereIcons[16],
            Enums.ActionType.CharacteristicLeechDmgPercentAll => GlobalData.Instance.SphereIcons[24],
            Enums.ActionType.CharacteristicGainOnHitFire => GlobalData.Instance.SphereIcons[5],
            Enums.ActionType.CharacteristicGainOnHitEarth => GlobalData.Instance.SphereIcons[6],
            Enums.ActionType.CharacteristicGainOnHitWater => GlobalData.Instance.SphereIcons[7],
            Enums.ActionType.CharacteristicGainOnHitWind => GlobalData.Instance.SphereIcons[4],
            Enums.ActionType.Teleport => GlobalData.Instance.SphereIcons[50],
            Enums.ActionType.Pull => GlobalData.Instance.SphereIcons[50],
            Enums.ActionType.Push => GlobalData.Instance.SphereIcons[50],
            Enums.ActionType.MoveTowardsTarget => GlobalData.Instance.SphereIcons[50],
            Enums.ActionType.PushedBackFromTarget => GlobalData.Instance.SphereIcons[50],
            Enums.ActionType.Carry => GlobalData.Instance.SphereIcons[50],
            Enums.ActionType.Throw => GlobalData.Instance.SphereIcons[50],
            Enums.ActionType.ExchangePosition => GlobalData.Instance.SphereIcons[50],
            Enums.ActionType.PropertyStable => GlobalData.Instance.SphereIcons[50],
            Enums.ActionType.PropertyDrunk => GlobalData.Instance.SphereIcons[5],
            Enums.ActionType.PropertyImmune => GlobalData.Instance.SphereIcons[13],
            Enums.ActionType.PropertyImmuneToSpell => GlobalData.Instance.SphereIcons[13],
            Enums.ActionType.PropertyNonTransposable => GlobalData.Instance.SphereIcons[50],
            Enums.ActionType.PropertyRooted => GlobalData.Instance.SphereIcons[50],
            Enums.ActionType.PropertyImmobilized => GlobalData.Instance.SphereIcons[50],
            Enums.ActionType.PropertyPetrified => GlobalData.Instance.SphereIcons[50],
            Enums.ActionType.PropertySpellRebound => GlobalData.Instance.SphereIcons[20],
            Enums.ActionType.PropertyInvisible => GlobalData.Instance.SphereIcons[19],
            Enums.ActionType.PropertyEvanescent => GlobalData.Instance.SphereIcons[13],
            Enums.ActionType.PropertyInvisibleForParent => GlobalData.Instance.SphereIcons[19],
            Enums.ActionType.AdaptLook => GlobalData.Instance.SphereIcons[50],
            Enums.ActionType.ChangeLook => GlobalData.Instance.SphereIcons[50],
            Enums.ActionType.Summon => GlobalData.Instance.SphereIcons[14],
            Enums.ActionType.SummonDouble => GlobalData.Instance.SphereIcons[14],
            Enums.ActionType.SummonMirror => GlobalData.Instance.SphereIcons[14],
            Enums.ActionType.SpellCooldownReset => GlobalData.Instance.SphereIcons[50],
            Enums.ActionType.InvertBonusCell => GlobalData.Instance.SphereIcons[50],
            Enums.ActionType.SetEffectArea => GlobalData.Instance.SphereIcons[50],
            Enums.ActionType.RemoveEffect => GlobalData.Instance.SphereIcons[50],
            Enums.ActionType.RevealInvisible => GlobalData.Instance.SphereIcons[19],
            Enums.ActionType.Death => GlobalData.Instance.SphereIcons[24],
            Enums.ActionType.Debuff => GlobalData.Instance.SphereIcons[50],
            Enums.ActionType.AttractSight => GlobalData.Instance.SphereIcons[19],
            Enums.ActionType.Bluff => GlobalData.Instance.SphereIcons[8],
            Enums.ActionType.MapDestruction => GlobalData.Instance.SphereIcons[50],
            Enums.ActionType.NoEffect => GlobalData.Instance.SphereIcons[50],
            _ => GlobalData.Instance.SphereIcons[34]
        };
    }
}
