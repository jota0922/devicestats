# Supabase セットアップ手順

このフォルダは DeviceStats の DB スキーマと初期データを格納します。
ファイルは Supabase Dashboard の SQL Editor に貼り付けて実行します。

## 実行順序

1. `migrations/001_init.sql` — テーブル定義
2. `migrations/002_rls.sql` — Row Level Security ポリシー
3. `seed/peripheral_categories.sql` — 周辺機器カテゴリのシードデータ
4. `seed/mice.sql` — マウスカタログのシードデータ（後で追加）

## アカウント・プロジェクト作成手順

1. https://supabase.com にアクセスし、GitHub または Email でサインアップ（無料）
2. New Project → 名前: `devicestats` / リージョン: `Northeast Asia (Tokyo)` を選択
3. パスワードを設定（あとで使うのでメモ）
4. プロジェクト作成完了まで2〜3分待つ
5. 左メニュー「SQL Editor」を開き、上記4ファイルを順番に貼り付けて Run

## 接続情報の取得

プロジェクト作成後、左メニュー「Project Settings」→「API」から以下をコピー：

- `Project URL` （例: `https://xxxx.supabase.co`）
- `anon public key` （フロントエンドから使う公開鍵）

これを Blazor アプリの `wwwroot/appsettings.json` などに保存します。
