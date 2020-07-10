# UniUISpriteText

UI の Image で文字画像を表示するためのコンポーネント 

## 使用例

![13](https://user-images.githubusercontent.com/6134875/87111101-8a104000-c2a3-11ea-9c14-fcb8c9b89032.gif)

## 使い方

![2020-07-10_114815](https://user-images.githubusercontent.com/6134875/87111119-92687b00-c2a3-11ea-958e-769288f160dc.png)

文字画像を表示するための Image を Scene に配置して  

![2020-07-10_114827](https://user-images.githubusercontent.com/6134875/87111124-93011180-c2a3-11ea-9d30-93fec89d575c.png)

親のゲームオブジェクトを用意して  

![2020-07-10_114904](https://user-images.githubusercontent.com/6134875/87111125-9399a800-c2a3-11ea-8630-838269633efb.png)

親のゲームオブジェクトに「UISpriteText」コンポーネントをアタッチします  

![2020-07-10_114939](https://user-images.githubusercontent.com/6134875/87111129-94323e80-c2a3-11ea-8abd-6c3403030f50.png)

次に、文字画像を用意して  

![2020-07-10_114954](https://user-images.githubusercontent.com/6134875/87111132-94323e80-c2a3-11ea-922a-c1642f938ace.png)

その文字画像を含む SpriteAtlas を作成して  

![2020-07-10_115014](https://user-images.githubusercontent.com/6134875/87111136-94cad500-c2a3-11ea-9102-7ef0db47d2da.png)

その SpriteAtlas をキャッシュする SpriteAtlasCacher（ https://github.com/baba-s/UniSpriteAtlasCacherAsset ）を作成して

![2020-07-10_115047](https://user-images.githubusercontent.com/6134875/87111137-94cad500-c2a3-11ea-86d7-80fa22fc94e4.png)

UISpriteText に設定します  

```cs
using Kogane;
using System.Collections;
using UnityEngine;

public class Example : MonoBehaviour
{
    public UISpriteText m_spriteTextUI;

    private IEnumerator Start()
    {
        var count = 0;

        while ( true )
        {
            m_spriteTextUI.SetValue( count++ );

            yield return new WaitForSeconds( 0.25f );
        }
    }
}
```

![13](https://user-images.githubusercontent.com/6134875/87111101-8a104000-c2a3-11ea-9c14-fcb8c9b89032.gif)

これで、UI の Image で文字画像を表示できるようになります  

![14](https://user-images.githubusercontent.com/6134875/87111105-8b416d00-c2a3-11ea-8f17-4f6dcf5bb6e3.gif)

「Is Zero Fill」をオンにすると 0 埋めされるようになります  

![15](https://user-images.githubusercontent.com/6134875/87111108-8c729a00-c2a3-11ea-8cc4-32880bb4c796.gif)

「Is Snap」をオフにすると、文字画像が変更される時に SetNativeSize が呼び出されないようになります  

![2020-07-10_120236](https://user-images.githubusercontent.com/6134875/87111837-4c141b80-c2a5-11ea-954c-42c622c54d08.png)

文字画像のファイル名に prefix が存在する場合は  

![2020-07-10_120255](https://user-images.githubusercontent.com/6134875/87111838-4d454880-c2a5-11ea-9f02-45252c073bda.png)

「Sprite Name Prefix」に指定します  

## 謝辞

* このリポジトリにサンプルには下記の無料アセットを使用させていただいております  
    * https://assetstore.unity.com/packages/2d/gui/puzzle-stage-settings-gui-pack-147389
