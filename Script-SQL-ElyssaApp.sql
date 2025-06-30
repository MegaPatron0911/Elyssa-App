-- -----------------------------------------------------
-- Table `ElyssaAPP`.`permisions`
-- -----------------------------------------------------
CREATE TABLE public.permissions (
  id uuid NOT NULL,
  name character varying NOT NULL UNIQUE,
  description text,
  CONSTRAINT permissions_pkey PRIMARY KEY (id)
);
-- -----------------------------------------------------
-- Table `ElyssaAPP`.`roles_permissions`
-- -----------------------------------------------------
CREATE TABLE public.role_permissions (
  role_id uuid NOT NULL,
  permission_id uuid NOT NULL,
  CONSTRAINT role_permissions_pkey PRIMARY KEY (role_id, permission_id),
  CONSTRAINT role_permissions_permission_id_fkey FOREIGN KEY (permission_id) REFERENCES public.permissions(id),
  CONSTRAINT role_permissions_role_id_fkey FOREIGN KEY (role_id) REFERENCES public.roles(id)
);
-- -----------------------------------------------------
-- Table `ElyssaAPP`.`roles`
-- -----------------------------------------------------
CREATE TABLE public.roles (
  id uuid NOT NULL,
  name character varying NOT NULL UNIQUE,
  CONSTRAINT roles_pkey PRIMARY KEY (id)
);
-- -----------------------------------------------------
-- Table `ElyssaAPP`.`users`
-- -----------------------------------------------------
CREATE TABLE public.users (
  id uuid NOT NULL,
  email character varying NOT NULL UNIQUE,
  name character varying NOT NULL,
  password_hash character varying NOT NULL,
  role_id uuid NOT NULL,
  CONSTRAINT users_pkey PRIMARY KEY (id),
  CONSTRAINT users_role_id_fkey FOREIGN KEY (role_id) REFERENCES public.roles(id)
);

-- Inserts para la tabla 'roles'
-- -----------------------------------------------------
INSERT INTO roles (id, name) VALUES
  ('11111111-1111-1111-1111-111111111111', 'admin'),
  ('22222222-2222-2222-2222-222222222222', 'user'),
  ('33333333-3333-3333-3333-333333333333', 'guest');

  -- Inserts para la tabla 'permissions'
-- -----------------------------------------------------
  INSERT INTO permissions (id, name, description) VALUES
  ('aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', 'read', 'Permite leer información'),
  ('bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb', 'write', 'Permite escribir información'),
  ('cccccccc-cccc-cccc-cccc-cccccccccccc', 'delete', 'Permite eliminar información');

-- Inserts para la tabla 'users'
-- -----------------------------------------------------
  INSERT INTO users (id, email, name, password_hash, role_id) VALUES
  ('d1d1d1d1-d1d1-d1d1-d1d1-d1d1d1d1d1d1', 'admin@demo.com', 'Admin Demo', 'hashed_password_1', '11111111-1111-1111-1111-111111111111'),
  ('e2e2e2e2-e2e2-e2e2-e2e2-e2e2e2e2e2e2', 'user@demo.com', 'User Demo', 'hashed_password_2', '22222222-2222-2222-2222-222222222222'),
  ('f3f3f3f3-f3f3-f3f3-f3f3-f3f3f3f3f3f3', 'guest@demo.com', 'Guest Demo', 'hashed_password_3', '33333333-3333-3333-3333-333333333333');

-- Inserts para la tabla 'role_permissions'
-- -----------------------------------------------------
-- El rol admin tiene todos los permisos
INSERT INTO role_permissions (role_id, permission_id) VALUES
  ('11111111-1111-1111-1111-111111111111', 'aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa'),
  ('11111111-1111-1111-1111-111111111111', 'bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb'),
  ('11111111-1111-1111-1111-111111111111', 'cccccccc-cccc-cccc-cccc-cccccccccccc');

-- El rol user tiene permisos de lectura y escritura
INSERT INTO role_permissions (role_id, permission_id) VALUES
  ('22222222-2222-2222-2222-222222222222', 'aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa'),
  ('22222222-2222-2222-2222-222222222222', 'bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb');

-- El rol guest solo tiene permiso de lectura
INSERT INTO role_permissions (role_id, permission_id) VALUES
  ('33333333-3333-3333-3333-333333333333', 'aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa');


