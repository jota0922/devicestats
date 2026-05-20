-- ============================================================
-- Grants : grant base privileges to anon and authenticated roles
-- RLS policies control row-level access; GRANTs control table access.
-- ============================================================

grant usage on schema public to anon, authenticated;

-- ------------------------------------------------------------
-- profiles : 誰でも読める / 本人だけ書ける
-- ------------------------------------------------------------
grant select on public.profiles to anon, authenticated;
grant insert, update, delete on public.profiles to authenticated;

-- ------------------------------------------------------------
-- mice : 誰でも読める / ログインユーザーが追加申請可
-- ------------------------------------------------------------
grant select on public.mice to anon, authenticated;
grant insert on public.mice to authenticated;
grant usage on sequence public.mice_id_seq to authenticated;

-- ------------------------------------------------------------
-- mouse_registrations : 誰でも読める / 本人だけ書ける
-- ------------------------------------------------------------
grant select on public.mouse_registrations to anon, authenticated;
grant insert, update, delete on public.mouse_registrations to authenticated;

-- ------------------------------------------------------------
-- peripheral_categories : 誰でも読める（読み取り専用）
-- ------------------------------------------------------------
grant select on public.peripheral_categories to anon, authenticated;

-- ------------------------------------------------------------
-- peripheral_registrations : 誰でも読める / 本人だけ書ける
-- ------------------------------------------------------------
grant select on public.peripheral_registrations to anon, authenticated;
grant insert, update, delete on public.peripheral_registrations to authenticated;
grant usage on sequence public.peripheral_registrations_id_seq to authenticated;
