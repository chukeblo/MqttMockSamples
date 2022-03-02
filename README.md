# MqttMockSamples

## 開発言語
C#

## 開発環境
Visual Studio 2019

## 外部依存パッケージ・フレームワーク
- Microsoft.NetCore.App (v5.0.0)
- MQTTnet (v3.1.2)

## ソリューション構成
- MqttMockSamples.sln
  - MqttBroker.csproj
  - MqttPublisher.csproj
  - MqttReceiver.csproj

### MqttBroker
MQTTプロコル通信でのブローカーのふるまいをするコンソールアプリケーション

### MqttPublisher
MQTTプロトコル通信でのクライアントとして指定されたトピックでメッセージのシミュレーションを実行するコンソールアプリケーション

### MqttReceiver
MQTTプロトコル通信でのクライアントとして指定されたトピックのSubscribeをおこなうコンソールアプリケーション
