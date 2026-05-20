-- ============================================================
-- Row Level Security policies
-- ============================================================

-- ------------------------------------------------------------
-- profiles
-- ------------------------------------------------------------
alter table public.profiles enable row level security;

create policy "profiles: anyone can read"
    on public.profiles for select
    using (true);

create policy "profiles: owner can insert"
    on public.profiles for insert
    with check (auth.uid() = user_id);

create policy "profiles: owner can update"
    on public.profiles for update
    using (auth.uid() = user_id)
    with check (auth.uid() = user_id);

create policy "profiles: owner can delete"
    on public.profiles for delete
    using (auth.uid() = user_id);

-- ------------------------------------------------------------
-- mice : everyone reads approved entries; users can submit new
-- ------------------------------------------------------------
alter table public.mice enable row level security;

create policy "mice: anyone can read approved"
    on public.mice for select
    using (approved = true or submitted_by = auth.uid());

create policy "mice: logged-in users can submit"
    on public.mice for insert
    with check (auth.uid() = submitted_by);

-- ------------------------------------------------------------
-- mouse_registrations
-- ------------------------------------------------------------
alter table public.mouse_registrations enable row level security;

create policy "mouse_regs: anyone can read"
    on public.mouse_registrations for select
    using (true);

create policy "mouse_regs: owner can insert"
    on public.mouse_registrations for insert
    with check (auth.uid() = user_id);

create policy "mouse_regs: owner can update"
    on public.mouse_registrations for update
    using (auth.uid() = user_id)
    with check (auth.uid() = user_id);

create policy "mouse_regs: owner can delete"
    on public.mouse_registrations for delete
    using (auth.uid() = user_id);

-- ------------------------------------------------------------
-- peripheral_categories : read-only for all
-- ------------------------------------------------------------
alter table public.peripheral_categories enable row level security;

create policy "categories: anyone can read"
    on public.peripheral_categories for select
    using (true);

-- ------------------------------------------------------------
-- peripheral_registrations
-- ------------------------------------------------------------
alter table public.peripheral_registrations enable row level security;

create policy "peripheral_regs: anyone can read"
    on public.peripheral_registrations for select
    using (true);

create policy "peripheral_regs: owner can insert"
    on public.peripheral_registrations for insert
    with check (auth.uid() = user_id);

create policy "peripheral_regs: owner can update"
    on public.peripheral_registrations for update
    using (auth.uid() = user_id)
    with check (auth.uid() = user_id);

create policy "peripheral_regs: owner can delete"
    on public.peripheral_registrations for delete
    using (auth.uid() = user_id);
