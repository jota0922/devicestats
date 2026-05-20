-- ============================================================
-- DeviceStats schema
-- Run this in Supabase Dashboard > SQL Editor
-- ============================================================

-- ------------------------------------------------------------
-- profiles : 1:1 with auth.users
-- ------------------------------------------------------------
create table if not exists public.profiles (
    user_id        uuid primary key references auth.users(id) on delete cascade,
    nickname       text not null check (char_length(nickname) between 1 and 40),
    hand_width_mm  int  check (hand_width_mm  between 50 and 150),
    hand_length_mm int  check (hand_length_mm between 100 and 250),
    dominant_hand  text check (dominant_hand in ('right','left','both')),
    created_at     timestamptz not null default now(),
    updated_at     timestamptz not null default now()
);

-- ------------------------------------------------------------
-- mice : canonical mouse catalog (seed + user-submitted)
-- ------------------------------------------------------------
create table if not exists public.mice (
    id            bigserial primary key,
    maker         text not null,
    model_name    text not null,
    approved      boolean not null default false,
    submitted_by  uuid references auth.users(id) on delete set null,
    created_at    timestamptz not null default now(),
    unique (maker, model_name)
);

create index if not exists idx_mice_approved on public.mice(approved);

-- ------------------------------------------------------------
-- mouse_registrations : 1 mouse per user
-- ------------------------------------------------------------
create table if not exists public.mouse_registrations (
    user_id     uuid primary key references auth.users(id) on delete cascade,
    mouse_id    bigint not null references public.mice(id) on delete restrict,
    main_game   text,
    grip_style  text check (grip_style in ('palm','claw','fingertip')),
    image_url   text,
    comment     text check (char_length(comment) <= 500),
    created_at  timestamptz not null default now(),
    updated_at  timestamptz not null default now()
);

create index if not exists idx_mouse_regs_mouse on public.mouse_registrations(mouse_id);

-- ------------------------------------------------------------
-- peripheral_categories : preset list
-- ------------------------------------------------------------
create table if not exists public.peripheral_categories (
    id            smallserial primary key,
    name          text not null unique,
    display_order smallint not null default 0
);

-- ------------------------------------------------------------
-- peripheral_registrations : many per user
-- ------------------------------------------------------------
create table if not exists public.peripheral_registrations (
    id           bigserial primary key,
    user_id      uuid not null references auth.users(id) on delete cascade,
    category_id  smallint not null references public.peripheral_categories(id),
    product_name text not null check (char_length(product_name) between 1 and 120),
    comment      text check (char_length(comment) <= 500),
    created_at   timestamptz not null default now()
);

create index if not exists idx_peripheral_regs_user on public.peripheral_registrations(user_id);
create index if not exists idx_peripheral_regs_cat  on public.peripheral_registrations(category_id);

-- ------------------------------------------------------------
-- updated_at auto trigger
-- ------------------------------------------------------------
create or replace function public.set_updated_at()
returns trigger language plpgsql as $$
begin
    new.updated_at := now();
    return new;
end;
$$;

drop trigger if exists trg_profiles_updated_at on public.profiles;
create trigger trg_profiles_updated_at
before update on public.profiles
for each row execute function public.set_updated_at();

drop trigger if exists trg_mouse_regs_updated_at on public.mouse_registrations;
create trigger trg_mouse_regs_updated_at
before update on public.mouse_registrations
for each row execute function public.set_updated_at();
