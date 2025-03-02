using System;

namespace EnhancedExperienceBar.Models
{
	// Token: 0x02000007 RID: 7
	public class PlayerExperience
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000A RID: 10 RVA: 0x00002225 File Offset: 0x00000425
		public double Current { get; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000B RID: 11 RVA: 0x0000222D File Offset: 0x0000042D
		public double ToNextLevel { get; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000C RID: 12 RVA: 0x00002235 File Offset: 0x00000435
		public double CurrentLevel { get; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000D RID: 13 RVA: 0x0000223D File Offset: 0x0000043D
		public float ExperiencePercentage { get; }

		// Token: 0x0600000E RID: 14 RVA: 0x00002245 File Offset: 0x00000445
		public PlayerExperience(double currentLevel, double current, double toNextLevel, float experiencePercentage)
		{
			this.Current = current;
			this.ToNextLevel = toNextLevel;
			this.ExperiencePercentage = experiencePercentage;
			this.CurrentLevel = currentLevel;
		}
	}
}
