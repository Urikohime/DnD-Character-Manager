using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnD_Character_Manager
{
    public partial class CharacterForm : Form
    {
        private int SW, SH;
        private String SPath;
        private Menu Paren;
        private bool CLOSER = false;

        public CharacterForm(Menu P, String Path)
        {
            SPath = Path;
            Paren = P;
            InitializeComponent();
        }

        public CharacterForm(Menu P, String DDCF, String Path)
        {
            SPath = Path;
            Paren = P;
            InitializeComponent();
            LoadDDC(DDCF);
        }

        private void BackBTN_Click(object sender, EventArgs e)
        {
            DialogResult DR = MessageBox.Show("Are you sure you want to quit?\nAll unsaved progress will be lost!", "Confirm", MessageBoxButtons.YesNo);
            if (DR == DialogResult.Yes)
            {
                Paren.Visible = true;
                CLOSER = true;
                this.Dispose();
                this.Close();
            }
            else
            {
                CLOSER = false;
            }
        }

        private void CreationFormClose(object sender, FormClosingEventArgs e)
        {
            if (CLOSER == false)
            {
                DialogResult DR = MessageBox.Show("Are you sure you want to quit?\nAll unsaved progress will be lost!", "Confirm", MessageBoxButtons.YesNo);
                if (DR == DialogResult.Yes || CLOSER == true)
                {
                    Paren.Visible = true;
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void EmptyTBCheck(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            if (TB.Text.Trim() == "" && !TB.Focused)
            {
                TB.Text = "0";
            }
        }

        private void GetFocus(object sender, EventArgs e)
        {
            try
            {
                TextBox TB = (TextBox)sender;
                if (TB.Text == "-" || TB.Text == "0" && TB.Focused)
                {
                    TB.Text = "";
                }
            }
            catch (Exception)
            {
                ComboBox TB = (ComboBox)sender;
                if (TB.Text == "-" && TB.Focused)
                {
                    TB.Text = "";
                }
            }

        }

        private void LostFocusWRD(object sender, EventArgs e)
        {
            try
            {
                TextBox TB = (TextBox)sender;
                if (TB.Text == "" && !TB.Focused)
                {
                    if (TB.Tag.ToString() == "WORD") { TB.Text = "-"; }
                    else if (TB.Tag.ToString() == "INT") { TB.Text = "0"; }
                }
            }
            catch (Exception)
            {
                ComboBox TB = (ComboBox)sender;
                if (TB.Text == "" && !TB.Focused)
                {
                    TB.Text = "-";
                }
            }
        }

        private void CheckTextChangeDB(object sender, EventArgs e)
        {
            ComboBox CB = (ComboBox)sender;
            if (CB.Text.Trim() == "" && !CB.Focused)
            {
                CB.Text = "-";
            }
        }

        private void SaveNQuitBtn_Click(object sender, EventArgs e)
        {
            DialogResult DR = DialogResult.None;
            if (File.Exists(SPath + "\\" + CNameTB.Text + ".DDC"))
            {
                DR = MessageBox.Show("A character with the name\n" + CNameTB.Text + "\nalready exists.\nDo you want to overwrite the character and exit the editor ?", "Existing Character / Exiting", MessageBoxButtons.YesNo);
            }
            if (DR == DialogResult.Yes || !File.Exists(CNameTB.Text + ".DDC"))
            {
                SaveDDC();
                CLOSER = true;
                Paren.Visible = true;
                this.Close();
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            DialogResult DR = DialogResult.None;
            if (File.Exists(SPath + "\\" + CNameTB.Text + ".DDC"))
            {
                DR = MessageBox.Show("A character with the name\n" + CNameTB.Text + "\nalready exists.\nDo you want to overwrite the character ?", "Existing Character", MessageBoxButtons.YesNo);
            }
            if (DR == DialogResult.Yes || !File.Exists(CNameTB.Text + ".DDC"))
            {
                SaveDDC();
            }
        }

        private void SaveDDC()
        {
            if (CNameTB.TextLength > 0 && CNameTB.Text != "ENTER A NAME")
            {
                try
                {
                    using (StreamWriter SW = File.CreateText(SPath + "\\" + CNameTB.Text + ".DDC"))
                    {
                        SW.Write(
                         "!!PLEASE ONLY USE THE PROGRAM TO EDIT THE CHARACTER!!" + "\n" +
                         "!!ONLY EDIT HERE IF NECESSARY!!" + "\n" + "\n" +
                        "MAINCHARSETTINGS" + "\n" +
                        "NAME=" + CNameTB.Text + "\n" +
                        "PLAYER=" + PNameTB.Text + "\n" +
                        "SPELLCLASS=" + CSpellcastingClassTB.Text + "\n" +
                        "CLASS=" + CClassCB.Text + "\n" +
                        "RACE=" + CRaceCB.Text + "\n" +
                        "BACKGROUND=" + CBackgroundCB.Text + "\n" +
                        "ALIGNMENT=" + CAlignmentCB.Text + "\n" +
                        "AGE=" + CAgeTB.Text + "\n" +
                        "EYES=" + CEyesTB.Text + "\n" +
                        "SKIN=" + CSkinTB.Text + "\n" +
                        "HAIR=" + CHairTB.Text + "\n" +
                        "HEIGHT=" + CHeightTB.Text + "\n" +
                        "WEIGHT=" + CWeightTB.Text + "\n" + "\n" +

                        "////////////" + "\n" +
                        "MAINCHARSTATS" + "\n" +
                        "STRENGTH=" + CStrengthTB.Text + "\n" +
                        "STRENGTH_MOD=" + CStatsModStrengthTB.Text + "\n" +
                        "DEXTERITY=" + CDexterityTB.Text + "\n" +
                        "DEXTERITY_MOD=" + CStatsModDexterityTB.Text + "\n" +
                        "CONSTITUTION=" + CConstitutionTB.Text + "\n" +
                        "CONSTITUTION_MOD=" + CStatsModConstitutionTB.Text + "\n" +
                        "INTELLIGENCE=" + CIntelligenceTB.Text + "\n" +
                        "INTELLIGENCE_MOD=" + CStatsModIntelligenceTB.Text + "\n" +
                        "WISDOM=" + CWisdomTB.Text + "\n" +
                        "WISDOM_MOD=" + CStatsModWisdomTB.Text + "\n" +
                        "CHARISMA=" + CCharismaTB.Text + "\n" +
                        "CHARISMA_MOD=" + CStatsModWisdomTB.Text + "\n" +
                        "PASSIVEWISDOM=" + CPassiveWisdomTB.Text + "\n" + "\n" +

                        "////////////" + "\n" +
                        "SAVINGTHROWS" + "\n" +
                        "BOOL_SAVING_STRENGTH=" + CSavingThrowStrengthCB.Checked + "\n" +
                        "SAVING_STRENGTH=" + CSavingThrowStengthTB.Text + "\n" +
                        "BOOL_SAVING_DEXTERITY=" + CSavingThrowCharismaCB.Checked + "\n" +
                        "SAVING_DEXTERITY=" + CSavingThrowDexterityTB.Text + "\n" +
                        "BOOL_SAVING_CONSTITUTION=" + CSavingThrowConstitutionCB.Checked + "\n" +
                        "SAVING_CONSTITUTION=" + CSavingThrowConstitutionTB.Text + "\n" +
                        "BOOL_SAVING_INTELLIGENCE=" + CSavingThrowIntelligenceCB.Checked + "\n" +
                        "SAVING_INTELLIGENCE=" + CSavingThrowIntelligenceTB.Text + "\n" +
                        "BOOL_SAVING_WISDOM=" + CSavingThrowWisdomCB.Checked + "\n" +
                        "SAVING_WISDOM=" + CSavingThrowWisdomTB.Text + "\n" +
                        "BOOL_SAVING_CHARISMA=" + CSavingThrowCharismaCB.Checked + "\n" +
                        "SAVING_CHARISMA=" + CSavingThrowCharismaTB.Text + "\n" + "\n" +

                        "////////////" + "\n" +
                        "SKILLS" + "\n" +
                        "BOOL_ACROBATICS=" + CSkillsAcrobaticsCB.Checked + "\n" +
                        "ACROBATICS=" + CSkillsAcrobaticsTB.Text + "\n" +
                        "BOOL_ANIMALHANDLING=" + CSkillsAnimalHandlingCB.Checked + "\n" +
                        "ANIMALHANDLING=" + CSkillsAnimalHandlingTB.Text + "\n" +
                        "BOOL_ARCANA=" + CSkillsArcanaCB.Checked + "\n" +
                        "ARCANA=" + CSkillsAcanaTB.Text + "\n" +
                        "BOOL_ATHLETICS=" + CSkillsAthleticsCB.Checked + "\n" +
                        "ATHLETICS=" + CSkillsAthleticsTB.Text + "\n" +
                        "BOOL_DECEPTION=" + CSkillsDeceptionCB.Checked + "\n" +
                        "DECEPTION=" + CSkillsDeceptionTB.Text + "\n" +
                        "BOOL_HISTORY=" + CSkillsHistoryCB.Checked + "\n" +
                        "HISTORY=" + CSkillsHistoryTB.Text + "\n" +
                        "BOOL_INSIGHT=" + CSkillsInsightCB.Checked + "\n" +
                        "INSIGHT=" + CSkillsInsightTB.Text + "\n" +
                        "BOOL_INTIMIDATION=" + CSkillsIntimidationCB.Checked + "\n" +
                        "INTIMIDATION=" + CSkillsIntimidationTB.Text + "\n" +
                        "BOOL_INVESTIGATION=" + CSkillsInvestigationCB.Checked + "\n" +
                        "INVESTIGATION=" + CSkillsInvestigationTB.Text + "\n" +
                        "BOOL_MEDICINE=" + CSkillsMedicineCB.Checked + "\n" +
                        "MEDICINE=" + CSkillsMedicineTB.Text + "\n" +
                        "BOOL_NATURE=" + CSkillsNatureCB.Checked + "\n" +
                        "NATURE=" + CSkillsNatureTB.Text + "\n" +
                        "BOOL_PERCEPTION=" + CSkillsPerceptionCB.Checked + "\n" +
                        "PERCEPTION=" + CSkillsPerceptionTB.Text + "\n" +
                        "BOOL_PERFORMANCE=" + CSkillsPerformanceCB.Checked + "\n" +
                        "PERFORMANCE=" + CSkillsPerformanceTB.Text + "\n" +
                        "BOOL_PERSUATION=" + CSkillsPersuationCB.Checked + "\n" +
                        "PERSUATION=" + CSkillsPersuationTB.Text + "\n" +
                        "BOOL_RELIGION=" + CSkillsReligionCB.Checked + "\n" +
                        "RELIGION=" + CSkillsReligionTB.Text + "\n" +
                        "BOOL_SLEIGHTOFHAND=" + CSkillsSleightOfHandCB.Checked + "\n" +
                        "SLEIGHTOFHAND=" + CSkillsSleightOfHandTB.Text + "\n" +
                        "BOOL_STEALTH=" + CSkillsStealthCB.Checked + "\n" +
                        "STEALTH=" + CSkillsStealthTB.Text + "\n" +
                        "BOOL_SURVIVAL=" + CSkillsSurvivalCB.Checked + "\n" +
                        "SURVIVAL=" + CSkillsSurvivalTB.Text + "\n" + "\n" +

                        "////////////" + "\n" +
                        "HEALTH_INSPIRATION_ETC" + "\n" +
                        "INSPIRATION=" + CInspirationTB.Text + "\n" +
                        "PROFICIENCY_BONUS=" + CProficiencyBonusTB.Text + "\n" +
                        "ARMORCLASS=" + CArmorClassTB.Text + "\n" +
                        "INITIATIVE=" + CInitiativeTB.Text + "\n" +
                        "SPEED=" + CSpeedTB.Text + "\n" +
                        "HIT_POINTS=" + CHitDiceTB.Text + "\n" +
                        "HIT_DICE=" + CHitDiceTB.Text + "\n" + "\n" +

                        "////////////" + "\n" +
                        "ATTACKS_SPELLCASTING" + "\n" +
                        "WEAPON_1_NAME=" + CWeaponName1TB.Text + "\n" +
                        "WEAPON_1_ATK_BONUS=" + CAtkBonus1TB.Text + "\n" +
                        "WEAPON_1_DAMAGE_TYPE=" + CDamageType1DD.Text + "\n" +
                        "WEAPON_2_NAME=" + CWeaponName2TB.Text + "\n" +
                        "WEAPON_2_ATK_BONUS=" + CAtkBonus2TB.Text + "\n" +
                        "WEAPON_2_DAMAGE_TYPE=" + CDamageType2DD.Text + "\n" +
                        "WEAPON_3_NAME=" + CWeaponName3TB.Text + "\n" +
                        "WEAPON_3_ATK_BONUS=" + CAtkBonus3TB.Text + "\n" +
                        "WEAPON_3_DAMAGE_TYPE=" + CDamageType3DD.Text + "\n" +
                        "WEAPON_4_NAME=" + CWeaponName4TB.Text + "\n" +
                        "WEAPON_4_ATK_BONUS=" + CAtkBonus4TB.Text + "\n" +
                        "WEAPON_4_DAMAGE_TYPE=" + CDamageType4DD.Text + "\n" +
                        "WEAPON_5_NAME=" + CWeaponName5TB.Text + "\n" +
                        "WEAPON_5_ATK_BONUS=" + CAtkBonus5TB.Text + "\n" +
                        "WEAPON_5_DAMAGE_TYPE=" + CDamageType5DD.Text + "\n" +
                        "WEAPON_6_NAME=" + CWeaponName6TB.Text + "\n" +
                        "WEAPON_6_ATK_BONUS=" + CAtkBonus6TB.Text + "\n" +
                        "WEAPON_6_DAMAGE_TYPE=" + CDamageType6DD.Text + "\n" + "\n" +

                        "////////////" + "\n" +
                        "MONEY" + "\n" +
                        "COPPER_PIECES=" + CCopperTB.Text + "\n" +
                        "SILVER_PIECES=" + CSilverTB.Text + "\n" +
                        "ELECTRUM_PIECES=" + CElectrumTB.Text + "\n" +
                        "GOLD_PIECES=" + CGoldTB.Text + "\n" +
                        "PLATINUM_PIECES=" + CPlatinumTB.Text + "\n" + "\n" +

                        "////////////" + "\n" +
                        "EQUIPMENT=" + CEquipmentTB.Text.Replace("\n", "EQUIPMENT=") + "\n" + "\n" +

                        "////////////" + "\n" +
                        "FEATURES_TRAITS=" + CFeaturesTraitsTB.Text.Replace("\n", "FEATURES_TRAITS=") + "\n" + "\n" +

                        "////////////" + "\n" +
                        "OTHER_PROFICIENCIES_LANGUAGES=" + CProficienciesLangsTB.Text.Replace("\n", "OTHER_PROFICIENCIES_LANGUAGES=") + "\n" + "\n" +

                        "////////////" + "\n" +
                        "CHARACTER_BACKSTORY=" + CBackstoryTB.Text.Replace("\n", "CHARACTER_BACKSTORY=") + "\n" + "\n" +

                        "////////////" + "\n" +
                        "ALLIES_ORGANIZATIONS=" + CAlliesOrganzTB.Text.Replace("\n", "ALLIES_ORGANIZATIONS=") + "\n" + "\n" +

                        "////////////" + "\n" +
                        "ADDITIONAL_FEATURES_TRAITS=" + CAdditionalFeaturesTraitsTB.Text.Replace("\n", "ADDITIONAL_FEATURES_TRAITS=") + "\n" + "\n" +

                        "////////////" + "\n" +
                        "TREASURE=" + CTreasureTB.Text.Replace("\n", "TREASURE=") + "\n" + "\n" +

                        "////////////" + "\n" +
                        "PERSONALITY_TRAITS=" + CPersonalityTraitsTB.Text.Replace("\n", "PERSONAITY_TRAITS=") + "\n" + "\n" +

                        "////////////" + "\n" +
                        "IDEALS=" + CIdealsTB.Text.Replace("\n", "IDEALS=") + "\n" + "\n" +

                        "////////////" + "\n" +
                        "BONDS=" + CBondsTB.Text.Replace("\n", "BONDS=") + "\n" + "\n" +

                        "////////////" + "\n" +
                        "FLAWS=" + CFlawsTB.Text.Replace("\n", "FLAWS=") + "\n" + "\n" +

                        "////////////" + "\n" +
                        "SPELLCASTING_ABILITY=" + CSpellcastingAbilityTB.Text + "\n" + "\n" +
                        "SPELL_SAVE_DICE=" + CSpellSaveDcTB.Text + "\n" + "\n" +
                        "SPELL_ATTACK_BONUS=" + CSpellAttackBonusTB.Text + "\n" + "\n" +

                        "////////////" + "\n" +
                        "SPELL_LEVEL_0=" + CSpellLv0TB.Text.Replace("\n", "SPELL_LEVEL_0=") + "\n" + "\n" +

                        "////////////" + "\n" +
                        "SPELL_LEVEL_1=" + CSpellLv1TB.Text.Replace("\n", "SPELL_LEVEL_1=") + "\n" + "\n" +

                        "////////////" + "\n" +
                        "SPELL_LEVEL_2=" + CSpellLv2TB.Text.Replace("\n", "SPELL_LEVEL_2=") + "\n" + "\n" +

                        "////////////" + "\n" +
                        "SPELL_LEVEL_3=" + CSpellLv3TB.Text.Replace("\n", "SPELL_LEVEL_3=") + "\n" + "\n" +

                        "////////////" + "\n" +
                        "SPELL_LEVEL_4=" + CSpellLv4TB.Text.Replace("\n", "SPELL_LEVEL_4=") + "\n" + "\n" +

                        "////////////" + "\n" +
                        "SPELL_LEVEL_5=" + CSpellLv5TB.Text.Replace("\n", "SPELL_LEVEL_5=") + "\n" + "\n" +

                        "////////////" + "\n" +
                        "SPELL_LEVEL_6=" + CSpellLv6TB.Text.Replace("\n", "SPELL_LEVEL_6=") + "\n" + "\n" +

                        "////////////" + "\n" +
                        "SPELL_LEVEL_7=" + CSpellLv7TB.Text.Replace("\n", "SPELL_LEVEL_7=") + "\n" + "\n" +

                        "////////////" + "\n" +
                        "SPELL_LEVEL_8=" + CSpellLv8TB.Text.Replace("\n", "SPELL_LEVEL_8=") + "\n" + "\n" +

                        "////////////" + "\n" +
                        "SPELL_LEVEL_9=" + CSpellLv9TB.Text.Replace("\n", "SPELL_LEVEL_9=") + "\n" + "\n"
                        );
                    }
                    MessageBox.Show("The Character: '" + CNameTB.Text + "' has been saved succsesfully!", "Saved", MessageBoxButtons.OK);
                } catch (Exception) { }
            }
            else
            {
                CNameTB.Text = "PLEASE ENTER A NAME";
            }
        }

        private void LoadDDC(String DDC)
        {
            using (StreamReader SR = new StreamReader(DDC))
            {
                while (!SR.EndOfStream)
                {
                    String DATATEMP = SR.ReadLine();
                    String[] DATADDC = DATATEMP.Split('=');
                    if (DATADDC[0] == "NAME") { CNameTB.Text = DATATEMP.Replace("NAME=", ""); }
                    if (DATADDC[0] == "PLAYER") { PNameTB.Text = DATATEMP.Replace("PLAYER=", ""); }
                    if (DATADDC[0] == "SPELLCLASS") { CSpellcastingClassTB.Text = DATATEMP.Replace("SPELLCLASS=", ""); }
                    if (DATADDC[0] == "CLASS") { CClassCB.Text = DATATEMP.Replace("CLASS=", ""); }
                    if (DATADDC[0] == "RACE") { CRaceCB.Text = DATATEMP.Replace("RACE=", ""); }
                    if (DATADDC[0] == "ALIGNMENT") { CAlignmentCB.Text = DATATEMP.Replace("ALIGNMENT=", ""); }
                    if (DATADDC[0] == "BACKGROUND") { CBackgroundCB.Text = DATATEMP.Replace("BACKGROUND=", ""); }
                    if (DATADDC[0] == "AGE") { CAgeTB.Text = DATATEMP.Replace("AGE=", ""); }
                    if (DATADDC[0] == "EYES") { CEyesTB.Text = DATATEMP.Replace("EYES=", ""); }
                    if (DATADDC[0] == "SKIN") { CSkinTB.Text = DATATEMP.Replace("SKIN=", ""); }
                    if (DATADDC[0] == "HAIR") { CHairTB.Text = DATATEMP.Replace("HAIR=", ""); }
                    if (DATADDC[0] == "HEIGHT") { CHeightTB.Text = DATATEMP.Replace("HEIGHT=", ""); }
                    if (DATADDC[0] == "WEIGTH") { CWeightTB.Text = DATATEMP.Replace("WEIGTH=", ""); }

                    if (DATADDC[0] == "STRENGTH") { CStrengthTB.Text = DATADDC[1];}
                    if (DATADDC[0] == "STRENGTH_MOD") { CStatsModStrengthTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "DEXTERITY") { CDexterityTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "DEXTERITY_MOD") { CStatsModDexterityTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "CONSTITUTION") { CConstitutionTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "CONSTITUTION_MOD") { CStatsModConstitutionTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "INTELLIGENCE") { CIntelligenceTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "INTELLIGENCE_MOD") { CStatsModIntelligenceTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "WISDOM") { CWisdomTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "WISDOM_MOD") { CStatsModWisdomTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "CHARISMA") { CCharismaTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "CHARISMA_MOD") { CStatsModWisdomTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "PASSIVEWISDOM") { CPassiveWisdomTB.Text = DATADDC[1]; }

                    if (DATADDC[0] == "BOOL_SAVING_STRENGTH") { try { CSavingThrowStrengthCB.Checked = bool.Parse(DATADDC[1]); } catch(Exception){ }; }
                    if (DATADDC[0] == "BOOL_SAVING_DEXTERITY") { try { CSavingThrowCharismaCB.Checked = bool.Parse(DATADDC[1]); } catch (Exception) { }; }
                    if (DATADDC[0] == "BOOL_SAVING_CONSTITUTION") { try { CSavingThrowConstitutionCB.Checked = bool.Parse(DATADDC[1]); } catch (Exception) { }; }
                    if (DATADDC[0] == "BOOL_SAVING_INTELLIGENCE") { try { CSavingThrowIntelligenceCB.Checked = bool.Parse(DATADDC[1]); } catch (Exception) { }; }
                    if (DATADDC[0] == "BOOL_SAVING_WISDOM") { try { CSavingThrowWisdomCB.Checked = bool.Parse(DATADDC[1]); } catch(Exception){ }; }
                    if (DATADDC[0] == "BOOL_SAVING_CHARISMA") { try { CSavingThrowCharismaCB.Checked = bool.Parse(DATADDC[1]); } catch(Exception){ }; }
                    if (DATADDC[0] == "SAVING_STRENGTH") { CSavingThrowStengthTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "SAVING_DEXTERITY") { CSavingThrowDexterityTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "SAVING_CONSTITUTION") { CSavingThrowConstitutionTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "SAVING_INTELLIGENCE") { CSavingThrowIntelligenceTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "SAVING_WISDOM") { CSavingThrowWisdomTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "SAVING_CHARISMA") { CSavingThrowCharismaTB.Text = DATADDC[1]; }

                    if (DATADDC[0] == "BOOL_ACROBATICS") { try { CSkillsAcrobaticsCB.Checked = bool.Parse(DATADDC[1]); } catch(Exception){ }; }
                    if (DATADDC[0] == "BOOL_ANIMALHANDLING") { try { CSkillsAnimalHandlingCB.Checked = bool.Parse(DATADDC[1]); } catch(Exception){ }; }
                    if (DATADDC[0] == "BOOL_ARCANA") { try { CSkillsArcanaCB.Checked = bool.Parse(DATADDC[1]); } catch(Exception){ }; }
                    if (DATADDC[0] == "BOOL_ATHLETICS") { try { CSkillsAthleticsCB.Checked = bool.Parse(DATADDC[1]); } catch(Exception){ }; }
                    if (DATADDC[0] == "BOOL_DECEPTION") { try { CSkillsDeceptionCB.Checked = bool.Parse(DATADDC[1]); } catch(Exception){ }; }
                    if (DATADDC[0] == "BOOL_HISTORY") { try { CSkillsHistoryCB.Checked = bool.Parse(DATADDC[1]); } catch(Exception){ }; }
                    if (DATADDC[0] == "BOOL_INSIGHT") { try { CSkillsInsightCB.Checked = bool.Parse(DATADDC[1]); } catch(Exception){ }; }
                    if (DATADDC[0] == "BOOL_INTIMIDATION") { try { CSkillsIntimidationCB.Checked = bool.Parse(DATADDC[1]); } catch(Exception){ }; }
                    if (DATADDC[0] == "BOOL_INVESTIGATION") { try { CSkillsInvestigationCB.Checked = bool.Parse(DATADDC[1]); } catch(Exception){ }; }
                    if (DATADDC[0] == "BOOL_MEDICINE") { try { CSkillsMedicineCB.Checked = bool.Parse(DATADDC[1]); } catch(Exception){ }; }
                    if (DATADDC[0] == "BOOL_NATURE") { try { CSkillsNatureCB.Checked = bool.Parse(DATADDC[1]); } catch(Exception){ }; }
                    if (DATADDC[0] == "BOOL_PERCEPTION") { try { CSkillsPerceptionCB.Checked = bool.Parse(DATADDC[1]); } catch(Exception){ }; }
                    if (DATADDC[0] == "BOOL_PERFORMANCE") { try { CSkillsPerformanceCB.Checked = bool.Parse(DATADDC[1]); } catch(Exception){ }; }
                    if (DATADDC[0] == "BOOL_PERSUATION") { try { CSkillsPersuationCB.Checked = bool.Parse(DATADDC[1]); } catch(Exception){ }; }
                    if (DATADDC[0] == "BOOL_RELIGION") { try { CSkillsReligionCB.Checked = bool.Parse(DATADDC[1]); } catch(Exception){ }; }
                    if (DATADDC[0] == "BOOL_SLEIGHTOFHAND") { try { CSkillsSleightOfHandCB.Checked = bool.Parse(DATADDC[1]); } catch(Exception){ }; }
                    if (DATADDC[0] == "BOOL_STEALTH") { try { CSkillsStealthCB.Checked = bool.Parse(DATADDC[1]); } catch(Exception){ }; }
                    if (DATADDC[0] == "BOOL_SURVIVAL") { try { CSkillsSurvivalCB.Checked = bool.Parse(DATADDC[1]); } catch(Exception){ }; }
                    if (DATADDC[0] == "ACROBATICS") { CSkillsAcrobaticsTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "ANIMALHANDLING") { CSkillsAnimalHandlingTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "ARCANA") { CSkillsAcanaTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "ATHLETICS") { CSkillsAthleticsTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "DECEPTION") { CSkillsDeceptionTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "HISTORY") { CSkillsHistoryTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "INSIGHT") { CSkillsInsightTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "INTIMIDATION") { CSkillsIntimidationTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "INVESTIGATION") { CSkillsInvestigationTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "MEDICINE") { CSkillsMedicineTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "NATURE") { CSkillsNatureTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "PERCEPTION") { CSkillsPerceptionTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "PERFORMANCE") { CSkillsPerformanceTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "PERSUATION") { CSkillsPersuationTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "RELIGION") { CSkillsReligionTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "SLEIGHTOFHAND") { CSkillsSleightOfHandTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "STEALTH") { CSkillsStealthTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "SURVIVAL") { CSkillsSurvivalTB.Text = DATADDC[1]; }

                    if (DATADDC[0] == "INSPIRATION") { CInspirationTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "PROFICIENCY_BONUS") { CProficiencyBonusTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "ARMORCLASS") { CArmorClassTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "INITIATIVE") { CInitiativeTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "SPEED") { CSpeedTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "HIT_POINTS") { CHitDiceTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "HIT_DICE") { CHitDiceTB.Text = DATADDC[1]; }

                    if (DATADDC[0] == "WEAPON_1_NAME") { CWeaponName1TB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "WEAPON_1_ATK_BONUS") { CAtkBonus1TB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "WEAPON_1_DAMAGE_TYPE") { CDamageType1DD.Text = DATADDC[1]; }
                    if (DATADDC[0] == "WEAPON_2_NAME") { CWeaponName2TB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "WEAPON_2_ATK_BONUS") { CAtkBonus2TB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "WEAPON_2_DAMAGE_TYPE") { CDamageType2DD.Text = DATADDC[1]; }
                    if (DATADDC[0] == "WEAPON_3_NAME") { CWeaponName3TB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "WEAPON_3_ATK_BONUS") { CAtkBonus3TB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "WEAPON_3_DAMAGE_TYPE") { CDamageType3DD.Text = DATADDC[1]; }
                    if (DATADDC[0] == "WEAPON_4_NAME") { CWeaponName4TB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "WEAPON_4_ATK_BONUS") { CAtkBonus4TB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "WEAPON_4_DAMAGE_TYPE") { CDamageType4DD.Text = DATADDC[1]; }
                    if (DATADDC[0] == "WEAPON_5_NAME") { CWeaponName5TB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "WEAPON_5_ATK_BONUS") { CAtkBonus5TB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "WEAPON_5_DAMAGE_TYPE") { CDamageType5DD.Text = DATADDC[1]; }
                    if (DATADDC[0] == "WEAPON_6_NAME") { CWeaponName6TB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "WEAPON_6_ATK_BONUS") { CAtkBonus6TB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "WEAPON_6_DAMAGE_TYPE") { CDamageType6DD.Text = DATADDC[1]; }

                    if (DATADDC[0] == "COPPER_PIECES" ) { CCopperTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "SILVER_PIECES" ) { CSilverTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "ELECTRUM_PIECES" ) { CElectrumTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "GOLD_PIECES" ) { CGoldTB.Text = DATADDC[1]; }
                    if (DATADDC[0] == "PLATINUM_PIECES" ) { CPlatinumTB.Text = DATADDC[1]; }

                    if (DATADDC[0] == "EQUIPMENT" && DATADDC[1] != "-") { try {
                            if (CEquipmentTB.Text == "-") { CEquipmentTB.Text = ""; };
                            CEquipmentTB.AppendText(DATATEMP.Replace("EQUIPMENT=", ""));
                        } catch (Exception) { }; CEquipmentTB.AppendText("\r\n"); }

                    if (DATADDC[0] == "FEATURES_TRAITS" && DATADDC[1] != "-") { try {
                            if (CFeaturesTraitsTB.Text == "-") { CFeaturesTraitsTB.Text = ""; };
                            CFeaturesTraitsTB.AppendText(DATATEMP.Replace("FEATURES_TRAITS=", ""));
                        } catch (Exception) { }; CFeaturesTraitsTB.AppendText("\r\n");}

                    if (DATADDC[0] == "OTHER_PROFICIENCIES_LANGUAGES" && DATADDC[1] != "-") { try {
                            if (CProficienciesLangsTB.Text == "-") { CProficienciesLangsTB.Text = ""; };
                            CProficienciesLangsTB.AppendText(DATATEMP.Replace("OTHER_PROFICIENCIES_LANGUAGES=", ""));
                        } catch (Exception) { }; CProficienciesLangsTB.AppendText("\r\n");}

                    if (DATADDC[0] == "CHARACTER_BACKSTORY" && DATADDC[1] != "-") { try {
                            if (CBackstoryTB.Text == "-") { CBackstoryTB.Text = ""; };
                            CBackstoryTB.AppendText(DATATEMP.Replace("CHARACTER_BACKSTORY=", ""));
                        } catch (Exception) { }; CBackstoryTB.AppendText("\r\n");}

                    if (DATADDC[0] == "ALLIES_ORGANIZATIONS" && DATADDC[1] != "-") { try {
                            if (CAlliesOrganzTB.Text == "-") { CAlliesOrganzTB.Text = ""; };
                            CAlliesOrganzTB.AppendText(DATATEMP.Replace("ALLIES_ORGANIZATIONS=", ""));
                        } catch (Exception) { }; CAlliesOrganzTB.AppendText("\r\n");}

                    if (DATADDC[0] == "ADDITIONAL_FEATURES_TRAITS" && DATADDC[1] != "-") { try {
                            if (CAdditionalFeaturesTraitsTB.Text == "-") { CAdditionalFeaturesTraitsTB.Text = ""; };
                            CAdditionalFeaturesTraitsTB.AppendText(DATATEMP.Replace("ADDITIONAL_FEATURES_TRAITS=", ""));
                        } catch (Exception) { }; CAdditionalFeaturesTraitsTB.AppendText("\r\n");}

                    if (DATADDC[0] == "TREASURE" && DATADDC[1] != "-") { try {
                            if (CTreasureTB.Text == "-") { CTreasureTB.Text = ""; };
                            CTreasureTB.AppendText(DATATEMP.Replace("TREASURE=", ""));
                        } catch (Exception) { }; CTreasureTB.AppendText("\r\n");}

                    if (DATADDC[0] == "PERSONALITY_TRAITS" && DATADDC[1] != "-") { try {
                            if (CPersonalityTraitsTB.Text == "-") { CPersonalityTraitsTB.Text = ""; };
                            CPersonalityTraitsTB.AppendText(DATATEMP.Replace("PERSONALITY_TRAITS=", ""));
                        } catch (Exception) { }; CPersonalityTraitsTB.AppendText("\r\n");}

                    if (DATADDC[0] == "IDEALS" && DATADDC[1] != "-") { try {
                            if (CIdealsTB.Text == "-") { CIdealsTB.Text = ""; };
                            CIdealsTB.AppendText(DATATEMP.Replace("IDEALS=", ""));
                        } catch (Exception) { }; CIdealsTB.AppendText("\r\n");}

                    if (DATADDC[0] == "BONDS" && DATADDC[1] != "-") { try {
                            if (CBondsTB.Text == "-") { CBondsTB.Text = ""; };
                            CBondsTB.AppendText(DATATEMP.Replace("BONDS=", ""));
                        } catch (Exception) { }; CBondsTB.AppendText("\r\n");}

                    if (DATADDC[0] == "FLAWS" && DATADDC[1] != "-") { try {
                            if (CFlawsTB.Text == "-") { CFlawsTB.Text = ""; };
                            CFlawsTB.AppendText(DATATEMP.Replace("FLAWS=", ""));
                        } catch (Exception) { }; CFlawsTB.AppendText("\r\n");}

                    if (DATADDC[0] == "SPELLCASTING_ABILITY" && DATADDC[1] != "-") { try {
                            if (CSpellcastingAbilityTB.Text == "-") { CSpellcastingAbilityTB.Text = ""; };
                            CSpellcastingAbilityTB.AppendText(DATATEMP.Replace("SPELLCASTING_ABILITY=", ""));
                        } catch (Exception) { }; CSpellcastingAbilityTB.AppendText("\r\n");}

                    if (DATADDC[0] == "SPELL_SAVE_DICE" && DATADDC[1] != "-") { try {
                            if (CSpellSaveDcTB.Text == "-") { CSpellSaveDcTB.Text = ""; };
                            CSpellSaveDcTB.AppendText(DATATEMP.Replace("SPELL_SAVE_DICE=", ""));
                        } catch (Exception) { }; CSpellSaveDcTB.AppendText("\r\n");}

                    if (DATADDC[0] == "SPELL_ATTACK_BONUS" && DATADDC[1] != "-") { try {
                            if (CSpellAttackBonusTB.Text == "-") { CSpellAttackBonusTB.Text = ""; };
                            CSpellAttackBonusTB.AppendText(DATATEMP.Replace("SPELL_ATTACK_BONUS=", ""));
                        } catch (Exception) { }; CSpellAttackBonusTB.AppendText("\r\n");}

                    if (DATADDC[0] == "SPELL_LEVEL_0" && DATADDC[1] != "-") { try {
                            if (CSpellLv0TB.Text == "-") { CSpellLv0TB.Text = ""; };
                            CSpellLv0TB.AppendText(DATATEMP.Replace("SPELL_LEVEL_0=", ""));
                        } catch (Exception) { }; CSpellLv0TB.AppendText("\r\n");}

                    if (DATADDC[0] == "SPELL_LEVEL_1" && DATADDC[1] != "-") { try {
                            if (CSpellLv1TB.Text == "-") { CSpellLv1TB.Text = ""; };
                            CSpellLv1TB.AppendText(DATATEMP.Replace("SPELL_LEVEL_1=", ""));
                        } catch (Exception) { }; CSpellLv1TB.AppendText("\r\n");}

                    if (DATADDC[0] == "SPELL_LEVEL_2" && DATADDC[1] != "-") { try {
                            if (CSpellLv2TB.Text == "-") { CSpellLv2TB.Text = ""; };
                            CSpellLv2TB.AppendText(DATATEMP.Replace("SPELL_LEVEL_2=", ""));
                        } catch (Exception) { }; CSpellLv2TB.AppendText("\r\n");}

                    if (DATADDC[0] == "SPELL_LEVEL_3" && DATADDC[1] != "-") { try {
                            if (CSpellLv3TB.Text == "-") { CSpellLv3TB.Text = ""; };
                            CSpellLv3TB.AppendText(DATATEMP.Replace("SPELL_LEVEL_3=", ""));
                        } catch (Exception) { }; CSpellLv3TB.AppendText("\r\n");}

                    if (DATADDC[0] == "SPELL_LEVEL_4" && DATADDC[1] != "-") { try {
                            if (CSpellLv4TB.Text == "-") { CSpellLv4TB.Text = ""; };
                            CSpellLv4TB.AppendText(DATATEMP.Replace("SPELL_LEVEL_4=", ""));
                        } catch (Exception) { }; CSpellLv4TB.AppendText("\r\n");}

                    if (DATADDC[0] == "SPELL_LEVEL_5" && DATADDC[1] != "-") { try {
                            if (CSpellLv5TB.Text == "-") { CSpellLv5TB.Text = ""; };
                            CSpellLv5TB.AppendText(DATATEMP.Replace("SPELL_LEVEL_5=", ""));
                        } catch (Exception) { }; CSpellLv5TB.AppendText("\r\n");}

                    if (DATADDC[0] == "SPELL_LEVEL_6" && DATADDC[1] != "-") { try {
                            if (CSpellLv6TB.Text == "-") { CSpellLv6TB.Text = ""; };
                            CSpellLv6TB.AppendText(DATATEMP.Replace("SPELL_LEVEL_6=", ""));
                        } catch (Exception) { }; CSpellLv6TB.AppendText("\r\n");}

                    if (DATADDC[0] == "SPELL_LEVEL_7" && DATADDC[1] != "-") { try {
                            if (CSpellLv7TB.Text == "-") { CSpellLv7TB.Text = ""; };
                            CSpellLv7TB.AppendText(DATATEMP.Replace("SPELL_LEVEL_7=", ""));
                        } catch (Exception) { }; CSpellLv7TB.AppendText("\r\n");}

                    if (DATADDC[0] == "SPELL_LEVEL_8" && DATADDC[1] != "-") { try {
                            if (CSpellLv8TB.Text == "-") { CSpellLv8TB.Text = ""; };
                            CSpellLv8TB.AppendText(DATATEMP.Replace("SPELL_LEVEL_8=", ""));
                        } catch (Exception) { }; CSpellLv8TB.AppendText("\r\n");}

                    if (DATADDC[0] == "SPELL_LEVEL_9" && DATADDC[1] != "-") { try {
                            if (CSpellLv9TB.Text == "-") { CSpellLv9TB.Text = ""; };
                            CSpellLv9TB.AppendText(DATATEMP.Replace("SPELL_LEVEL_9=", ""));
                        } catch (Exception) { }; CSpellLv9TB.AppendText("\r\n");}
                }
            }
        }
    }
}
