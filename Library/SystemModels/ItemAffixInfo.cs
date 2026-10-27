using System;
using System.Collections.Generic;
using MirDB;

namespace Library.SystemModels
{
    /// <summary>
    /// 条件词条的触发条件类型（暗黑风格词条）
    /// </summary>
    public enum AffixConditionType
    {
        /// <summary>无（静态词条，属性直接生效）</summary>
        None,
        /// <summary>血量低于{参数}%时生效</summary>
        HealthPercentBelow,
        /// <summary>魔法低于{参数}%时生效</summary>
        MagicPercentBelow,
        /// <summary>夜间生效（无需参数）</summary>
        NightTime,
    }

    /// <summary>
    /// 装备词条配置（类似暗黑破坏神2的词缀），由管理后台维护
    /// </summary>
    public class ItemAffixInfo : DBObject
    {
        public string AffixName
        {
            get { return _AffixName; }
            set
            {
                if (_AffixName == value) return;

                var oldValue = _AffixName;
                _AffixName = value;

                OnChanged(oldValue, value, "AffixName");
            }
        }
        private string _AffixName;

        /// <summary>
        /// 显示模板，支持 {0} {1} ... 占位符，例如：血量低于{0}%时，暴击率增加{1}%
        /// </summary>
        public string Template
        {
            get { return _Template; }
            set
            {
                if (_Template == value) return;

                var oldValue = _Template;
                _Template = value;

                OnChanged(oldValue, value, "Template");
            }
        }
        private string _Template;

        /// <summary>
        /// 占位符参数定义 JSON：[{"Min":10,"Max":30},{"Min":5,"Max":10}]
        /// </summary>
        public string ParamsJson
        {
            get { return _ParamsJson; }
            set
            {
                if (_ParamsJson == value) return;

                var oldValue = _ParamsJson;
                _ParamsJson = value;

                OnChanged(oldValue, value, "ParamsJson");
            }
        }
        private string _ParamsJson;

        /// <summary>
        /// 效果定义 JSON：[{"Stat":"CriticalChance","UseParam":true,"ParamIndex":1,"FixedAmount":0}]
        /// </summary>
        public string EffectsJson
        {
            get { return _EffectsJson; }
            set
            {
                if (_EffectsJson == value) return;

                var oldValue = _EffectsJson;
                _EffectsJson = value;

                OnChanged(oldValue, value, "EffectsJson");
            }
        }
        private string _EffectsJson;

        /// <summary>
        /// 触发条件类型
        /// </summary>
        public AffixConditionType ConditionType
        {
            get { return _ConditionType; }
            set
            {
                if (_ConditionType == value) return;

                var oldValue = _ConditionType;
                _ConditionType = value;

                OnChanged(oldValue, value, "ConditionType");
            }
        }
        private AffixConditionType _ConditionType;

        /// <summary>
        /// 条件参数引用的占位符索引（-1 表示不引用占位符）
        /// </summary>
        public int ConditionParamIndex
        {
            get { return _ConditionParamIndex; }
            set
            {
                if (_ConditionParamIndex == value) return;

                var oldValue = _ConditionParamIndex;
                _ConditionParamIndex = value;

                OnChanged(oldValue, value, "ConditionParamIndex");
            }
        }
        private int _ConditionParamIndex;

        /// <summary>
        /// 适用装备类型（逗号分隔的 ItemType 名称，如 Weapon,Armour,Helmet；空 = 全部装备类型）
        /// </summary>
        public string ApplicableTypes
        {
            get { return _ApplicableTypes; }
            set
            {
                if (_ApplicableTypes == value) return;

                var oldValue = _ApplicableTypes;
                _ApplicableTypes = value;

                OnChanged(oldValue, value, "ApplicableTypes");
            }
        }
        private string _ApplicableTypes;

        /// <summary>
        /// 适用装备最小等级（RequiredAmount），-1 = 不限
        /// </summary>
        public int MinLevel
        {
            get { return _MinLevel; }
            set
            {
                if (_MinLevel == value) return;

                var oldValue = _MinLevel;
                _MinLevel = value;

                OnChanged(oldValue, value, "MinLevel");
            }
        }
        private int _MinLevel;

        /// <summary>
        /// 适用装备最大等级（RequiredAmount），-1 = 不限
        /// </summary>
        public int MaxLevel
        {
            get { return _MaxLevel; }
            set
            {
                if (_MaxLevel == value) return;

                var oldValue = _MaxLevel;
                _MaxLevel = value;

                OnChanged(oldValue, value, "MaxLevel");
            }
        }
        private int _MaxLevel;

        /// <summary>
        /// 出现权重（候选池内按权重随机，越大越容易出现）
        /// </summary>
        public int Weight
        {
            get { return _Weight; }
            set
            {
                if (_Weight == value) return;

                var oldValue = _Weight;
                _Weight = value;

                OnChanged(oldValue, value, "Weight");
            }
        }
        private int _Weight;

        public bool Enabled
        {
            get { return _Enabled; }
            set
            {
                if (_Enabled == value) return;

                var oldValue = _Enabled;
                _Enabled = value;

                OnChanged(oldValue, value, "Enabled");
            }
        }
        private bool _Enabled = true;

    }
}