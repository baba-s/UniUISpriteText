﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Kogane
{
	/// <summary>
	/// 文字を画像で表示するコンポーネント
	/// </summary>
	[DisallowMultipleComponent]
	public sealed class UISpriteText : MonoBehaviour
	{
		//==============================================================================
		// 変数(SerializeField)
		//==============================================================================
		[SerializeField] private SpriteAtlasCacher m_spriteAtlasCacher = default;
		[SerializeField] private string            m_spriteNamePrefix  = default;
		[SerializeField] private bool              m_isZeroFill        = default;

		//==============================================================================
		// 変数
		//==============================================================================
		private Image[] m_imageList;
		private bool    m_isInit;

		//==============================================================================
		// プロパティ
		//==============================================================================
		public IReadOnlyList<Image> ImageList => m_imageList;

		//==============================================================================
		// 関数
		//==============================================================================
		/// <summary>
		/// 初期化する時に呼び出されます
		/// </summary>
		private void Awake()
		{
			Init();
		}

		/// <summary>
		/// 初期化します
		/// </summary>
		private void Init()
		{
			if ( m_isInit ) return;
			m_isInit = true;

			m_imageList = gameObject
					.GetComponentsInChildren<Image>( true )
					.Where( x => x.gameObject != gameObject )
					.OrderBy( x => x.gameObject.name )
					.ToArray()
				;
		}

		/// <summary>
		/// 値を設定します
		/// </summary>
		public void SetValue( uint value )
		{
			SetValue( ( int ) value );
		}

		/// <summary>
		/// 値を設定します
		/// </summary>
		public void SetValue( int value )
		{
			Init();

			var text = m_isZeroFill
				? value.ToString( "D" + m_imageList.Length.ToString() )
				: value.ToString();

			var offset = m_imageList.Length - text.Length;

			for ( int i = 0; i < m_imageList.Length; i++ )
			{
				var inverseIndex = m_imageList.Length - i - 1;
				var val          = m_imageList[ i ];

				if ( text.Length <= inverseIndex )
				{
					val.gameObject.SetActive( false );
					continue;
				}

				var number     = text[ i - offset ];
				var spriteName = m_spriteNamePrefix + number.ToString();
				var sprite     = m_spriteAtlasCacher.GetSprite( spriteName );

				val.gameObject.SetActive( true );
				val.sprite = sprite;
			}
		}
	}

	/// <summary>
	/// UISpriteText 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class UISpriteTextExt
	{
		/// <summary>
		/// 値を設定します
		/// </summary>
		public static void SetValueIfNotNull( this UISpriteText self, uint value )
		{
			if ( self == null ) return;
			self.SetValue( value );
		}

		/// <summary>
		/// 値を設定します
		/// </summary>
		public static void SetValueIfNotNull( this UISpriteText self, int value )
		{
			if ( self == null ) return;
			self.SetValue( value );
		}
	}
}