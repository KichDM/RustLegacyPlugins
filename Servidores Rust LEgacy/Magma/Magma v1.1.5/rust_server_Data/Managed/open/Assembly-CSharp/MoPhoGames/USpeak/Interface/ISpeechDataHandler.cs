using System;

namespace MoPhoGames.USpeak.Interface
{
	// Token: 0x020000D3 RID: 211
	public interface ISpeechDataHandler
	{
		// Token: 0x06000419 RID: 1049
		void USpeakOnSerializeAudio(byte[] data);

		// Token: 0x0600041A RID: 1050
		void USpeakInitializeSettings(int data);
	}
}
