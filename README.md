# DeviceStats

PCデバイス（マウス中心）の登録と統計を可視化するWebアプリ。

## 技術スタック

- **フロントエンド**: Blazor WebAssembly (.NET 10)
- **バックエンド/DB**: Supabase (PostgreSQL + Auth)
- **ホスティング**: Cloudflare Pages (静的配信)
- **CI/CD**: GitHub Actions

## ローカル開発

```powershell
dotnet run --urls http://localhost:5151
```

ブラウザで http://localhost:5151 を開く。

## デプロイ

`main` ブランチに push すると、GitHub Actions が自動で Cloudflare Pages にデプロイします。

### 必要な GitHub Secrets

- `CLOUDFLARE_API_TOKEN` — Cloudflare の API トークン（Pages の編集権限）
- `CLOUDFLARE_ACCOUNT_ID` — Cloudflare のアカウント ID

## DB スキーマ

`supabase/` フォルダ参照。`supabase/README.md` にセットアップ手順あり。
