﻿using System;
using BlackJack.BJFramework.Runtime.Lua;
using ProtoBuf;
using SLua;

namespace BlackJack.ProjectL.Protocol
{
	// Token: 0x0200078D RID: 1933
	[ProtoContract(Name = "GuildMassiveCombatDataReq")]
	[HotFix(true, m_isCtorOnly = true)]
	[Serializable]
	public class GuildMassiveCombatDataReq : IExtensible
	{
		// Token: 0x060063B6 RID: 25526 RVA: 0x001C0194 File Offset: 0x001BE394
		public GuildMassiveCombatDataReq()
		{
			if (!BJLuaObjHelper.IsSkipLuaHotfix && this.TryInitHotFix("") && this.m_ctor_hotfix != null)
			{
				this.m_ctor_hotfix.call(new object[]
				{
					this
				});
				return;
			}
			BJLuaObjHelper.IsSkipLuaHotfix = false;
		}

		// Token: 0x060063B7 RID: 25527 RVA: 0x001C01FC File Offset: 0x001BE3FC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x060063B8 RID: 25528 RVA: 0x001C020C File Offset: 0x001BE40C
		private bool InitHotFix(LuaTable A_1)
		{
			this.m_luaObjHelper = new BJLuaObjHelper();
			this.m_luaObjHelper.InitInCS(this, A_1);
			LuaFunction luaFunction = A_1.RawGet("HotFixObject") as LuaFunction;
			bool result;
			if (luaFunction == null)
			{
				Debug.LogError("Can't find HotFixObject Func");
				result = false;
			}
			else
			{
				luaFunction.call(new object[]
				{
					this,
					this.m_luaObjHelper
				});
				LuaTable luaObj = this.m_luaObjHelper.GetLuaObj();
				if (luaObj == null)
				{
					result = false;
				}
				else
				{
					this.m_ctor_hotfix = (luaObj.RawGet("ctor") as LuaFunction);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x060063B9 RID: 25529 RVA: 0x001C02D8 File Offset: 0x001BE4D8
		private bool TryInitHotFix(string luaModuleName)
		{
			bool result;
			if (this.m_hotfixState != ObjectLuaHotFixState.Uninit)
			{
				result = (this.m_hotfixState == ObjectLuaHotFixState.InitAvialable);
			}
			else
			{
				bool flag = LuaManager.TryInitHotfixForObj(this, luaModuleName, typeof(GuildMassiveCombatDataReq));
				this.m_hotfixState = ((!flag) ? ObjectLuaHotFixState.InitUnavialable : ObjectLuaHotFixState.InitAvialable);
				result = flag;
			}
			return result;
		}

		// Token: 0x04004AC0 RID: 19136
		private IExtension extensionObject;

		// Token: 0x04004AC1 RID: 19137
		private BJLuaObjHelper m_luaObjHelper;

		// Token: 0x04004AC2 RID: 19138
		private ObjectLuaHotFixState m_hotfixState;

		// Token: 0x04004AC3 RID: 19139
		private LuaFunction m_ctor_hotfix;
	}
}
