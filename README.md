# ProBuilderModeLogger

ブログ記事
https://zenn.dev/articles/50339bacf4a402/edit

# ProBuilderModeLogger

ProBuilderModeLoggerは、ProBuilderの操作を向上させるためのUnity Editor拡張機能です。最初に選択された要素に基づいて選択モード（頂点、エッジ、面）を管理・固定し、次の選択が行われるまでモードを維持します。また、選択された頂点、エッジ、面の詳細な情報をリアルタイムでデバッグ出力します。

## 特徴

- **選択モードの固定**: 最初の選択に基づいてモードを自動的にロック。
- **リアルタイムデバッグ**: 選択内容の詳細をUnityのコンソールに出力。
- **効率的な選択管理**: 選択内容を比較し、冗長なデバッグ出力を防止。

## インストール

1. このリポジトリをクローンまたはダウンロードします。
2. `ProBuilderModeLogger`スクリプトをUnityプロジェクトの`Assets/Editor`フォルダに配置します。

## 使用方法

1. UnityでProBuilderオブジェクトを含むシーンを開きます。
2. ProBuilderで頂点、エッジ、面を選択します。
3. 最初に選択された要素に基づいて選択モードが固定されます。
4. Unityコンソールに詳細なデバッグ情報が表示されます。

## 必要条件

- Unity 2019.4以降
- ProBuilderパッケージがインストールされたプロジェクト

## 貢献

問題の報告やプルリクエストの送信により、プロジェクトに貢献してください。

## ライセンス

このプロジェクトはMITライセンスの下でライセンスされています。詳細は`LICENSE`ファイルをご覧ください。

# ProBuilderModeLogger

ProBuilderModeLogger is a Unity Editor extension that enhances the ProBuilder experience by managing and locking the selection mode (Vertex, Edge, Face) based on the first selected element. This tool ensures that the selection mode remains consistent until the user explicitly changes it, and provides real-time debugging information for selected vertices, edges, or faces.

## Features

- **Selection Mode Locking**: Automatically locks the selection mode based on the first selected element.
- **Real-time Debugging**: Outputs detailed information about the selected vertices, edges, or faces in the Unity Console.
- **Efficient Selection Management**: Compares current and previous selections to avoid redundant debug outputs.

## Installation

1. Clone or download this repository.
2. Place the `ProBuilderModeLogger` script into your Unity project's `Assets/Editor` folder.

## Usage

1. Open a scene in Unity with a ProBuilder object.
2. Select vertices, edges, or faces in ProBuilder.
3. The selection mode will be locked based on your first selection.
4. View the detailed debug information in the Unity Console.

## Requirements

- Unity 2019.4 or later.
- ProBuilder package installed in your project.

## Contributing

Feel free to contribute by opening issues or submitting pull requests.

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.
