--
-- PostgreSQL database cluster dump
--

SET default_transaction_read_only = off;

SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;

--
-- Drop databases (except postgres and template1)
--

DROP DATABASE "HospitalDb";




--
-- Drop roles
--

DROP ROLE postgres;


--
-- Roles
--

CREATE ROLE postgres;
ALTER ROLE postgres WITH SUPERUSER INHERIT CREATEROLE CREATEDB LOGIN REPLICATION BYPASSRLS PASSWORD 'SCRAM-SHA-256$4096:ajSG4b/vMyXogUDaNGqJUg==$mSfEgirqMW6kzFTZ4nln3Xwg//9bGvnOF2mZEaX0F3s=:mNe09HboD0aM3PHe0+EQDtjPid7MeWV9Ez936Y5KEvY=';

--
-- User Configurations
--








--
-- Databases
--

--
-- Database "template1" dump
--

--
-- PostgreSQL database dump
--

-- Dumped from database version 17.0 (Debian 17.0-1.pgdg120+1)
-- Dumped by pg_dump version 17.0 (Debian 17.0-1.pgdg120+1)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

UPDATE pg_catalog.pg_database SET datistemplate = false WHERE datname = 'template1';
DROP DATABASE template1;
--
-- Name: template1; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE template1 WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'en_US.utf8';


ALTER DATABASE template1 OWNER TO postgres;

\connect template1

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: DATABASE template1; Type: COMMENT; Schema: -; Owner: postgres
--

COMMENT ON DATABASE template1 IS 'default template for new databases';


--
-- Name: template1; Type: DATABASE PROPERTIES; Schema: -; Owner: postgres
--

ALTER DATABASE template1 IS_TEMPLATE = true;


\connect template1

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: DATABASE template1; Type: ACL; Schema: -; Owner: postgres
--

REVOKE CONNECT,TEMPORARY ON DATABASE template1 FROM PUBLIC;
GRANT CONNECT ON DATABASE template1 TO PUBLIC;


--
-- PostgreSQL database dump complete
--

--
-- Database "HospitalDb" dump
--

--
-- PostgreSQL database dump
--

-- Dumped from database version 17.0 (Debian 17.0-1.pgdg120+1)
-- Dumped by pg_dump version 17.0 (Debian 17.0-1.pgdg120+1)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: HospitalDb; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE "HospitalDb" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'en_US.utf8';


ALTER DATABASE "HospitalDb" OWNER TO postgres;

\connect "HospitalDb"

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: Analyzes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Analyzes" (
    "Id" uuid NOT NULL,
    "Type" text NOT NULL,
    "Date" date NOT NULL,
    "Result" text NOT NULL,
    "HistoryId" uuid NOT NULL,
    "AppointmentId" uuid NOT NULL
);


ALTER TABLE public."Analyzes" OWNER TO postgres;

--
-- Name: Appointments; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Appointments" (
    "Id" uuid NOT NULL,
    "Content" text NOT NULL,
    "ExaminationId" uuid NOT NULL
);


ALTER TABLE public."Appointments" OWNER TO postgres;

--
-- Name: Examinations; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Examinations" (
    "Id" uuid NOT NULL,
    "Date" date NOT NULL,
    "Conclusion" text,
    "HistoryId" uuid NOT NULL,
    "UserId" uuid NOT NULL
);


ALTER TABLE public."Examinations" OWNER TO postgres;

--
-- Name: Histories; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Histories" (
    "Id" uuid NOT NULL,
    "Diagnosis" text,
    "ArriveDate" date NOT NULL,
    "PatientId" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "DepartureDate" date,
    "LifeAnamnesis" text NOT NULL,
    "DiseaseAnamnesis" text NOT NULL,
    "Epicrisis" text,
    "Complaints" text NOT NULL
);


ALTER TABLE public."Histories" OWNER TO postgres;

--
-- Name: Marks; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Marks" (
    "Id" uuid NOT NULL,
    "IsDone" boolean NOT NULL,
    "Date" date NOT NULL,
    "UserId" uuid NOT NULL,
    "AppointmentId" uuid NOT NULL
);


ALTER TABLE public."Marks" OWNER TO postgres;

--
-- Name: Patients; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Patients" (
    "Id" uuid NOT NULL,
    "FIO" text NOT NULL,
    "Telephone" text NOT NULL,
    "Passport" text NOT NULL,
    "BirthDate" date NOT NULL,
    "Address" text NOT NULL
);


ALTER TABLE public."Patients" OWNER TO postgres;

--
-- Name: Users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Users" (
    "Id" uuid NOT NULL,
    "FIO" text NOT NULL,
    "Telephone" text NOT NULL,
    "Login" text NOT NULL,
    "Password" text NOT NULL,
    "Role" integer NOT NULL
);


ALTER TABLE public."Users" OWNER TO postgres;

--
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

--
-- Data for Name: Analyzes; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Analyzes" ("Id", "Type", "Date", "Result", "HistoryId", "AppointmentId") FROM stdin;
\.


--
-- Data for Name: Appointments; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Appointments" ("Id", "Content", "ExaminationId") FROM stdin;
\.


--
-- Data for Name: Examinations; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Examinations" ("Id", "Date", "Conclusion", "HistoryId", "UserId") FROM stdin;
\.


--
-- Data for Name: Histories; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Histories" ("Id", "Diagnosis", "ArriveDate", "PatientId", "UserId", "DepartureDate", "LifeAnamnesis", "DiseaseAnamnesis", "Epicrisis", "Complaints") FROM stdin;
\.


--
-- Data for Name: Marks; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Marks" ("Id", "IsDone", "Date", "UserId", "AppointmentId") FROM stdin;
\.


--
-- Data for Name: Patients; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Patients" ("Id", "FIO", "Telephone", "Passport", "BirthDate", "Address") FROM stdin;
\.


--
-- Data for Name: Users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Users" ("Id", "FIO", "Telephone", "Login", "Password", "Role") FROM stdin;
d99969a3-6dd6-41bb-b84e-4f4f47017bfd	Genadiy Gena Genachka	+79781195738	gena	RzKH+CmNunFjqJeQiVj3wOrnM+JdLgJ5kuou3JvtL6g=	1
\.


--
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20241127102925_Initial	9.0.0
20241129101213_UserUniqueConstraint	9.0.0
\.


--
-- Name: Analyzes PK_Analyzes; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Analyzes"
    ADD CONSTRAINT "PK_Analyzes" PRIMARY KEY ("Id");


--
-- Name: Appointments PK_Appointments; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Appointments"
    ADD CONSTRAINT "PK_Appointments" PRIMARY KEY ("Id");


--
-- Name: Examinations PK_Examinations; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Examinations"
    ADD CONSTRAINT "PK_Examinations" PRIMARY KEY ("Id");


--
-- Name: Histories PK_Histories; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Histories"
    ADD CONSTRAINT "PK_Histories" PRIMARY KEY ("Id");


--
-- Name: Marks PK_Marks; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Marks"
    ADD CONSTRAINT "PK_Marks" PRIMARY KEY ("Id");


--
-- Name: Patients PK_Patients; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Patients"
    ADD CONSTRAINT "PK_Patients" PRIMARY KEY ("Id");


--
-- Name: Users PK_Users; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "PK_Users" PRIMARY KEY ("Id");


--
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- Name: IX_Analyzes_AppointmentId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Analyzes_AppointmentId" ON public."Analyzes" USING btree ("AppointmentId");


--
-- Name: IX_Analyzes_HistoryId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Analyzes_HistoryId" ON public."Analyzes" USING btree ("HistoryId");


--
-- Name: IX_Appointments_ExaminationId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Appointments_ExaminationId" ON public."Appointments" USING btree ("ExaminationId");


--
-- Name: IX_Examinations_HistoryId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Examinations_HistoryId" ON public."Examinations" USING btree ("HistoryId");


--
-- Name: IX_Examinations_UserId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Examinations_UserId" ON public."Examinations" USING btree ("UserId");


--
-- Name: IX_Histories_PatientId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Histories_PatientId" ON public."Histories" USING btree ("PatientId");


--
-- Name: IX_Histories_UserId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Histories_UserId" ON public."Histories" USING btree ("UserId");


--
-- Name: IX_Marks_AppointmentId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "IX_Marks_AppointmentId" ON public."Marks" USING btree ("AppointmentId");


--
-- Name: IX_Marks_UserId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Marks_UserId" ON public."Marks" USING btree ("UserId");


--
-- Name: IX_Users_Login; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "IX_Users_Login" ON public."Users" USING btree ("Login");


--
-- Name: Analyzes FK_Analyzes_Appointments_AppointmentId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Analyzes"
    ADD CONSTRAINT "FK_Analyzes_Appointments_AppointmentId" FOREIGN KEY ("AppointmentId") REFERENCES public."Appointments"("Id") ON DELETE CASCADE;


--
-- Name: Analyzes FK_Analyzes_Histories_HistoryId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Analyzes"
    ADD CONSTRAINT "FK_Analyzes_Histories_HistoryId" FOREIGN KEY ("HistoryId") REFERENCES public."Histories"("Id") ON DELETE CASCADE;


--
-- Name: Appointments FK_Appointments_Examinations_ExaminationId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Appointments"
    ADD CONSTRAINT "FK_Appointments_Examinations_ExaminationId" FOREIGN KEY ("ExaminationId") REFERENCES public."Examinations"("Id") ON DELETE CASCADE;


--
-- Name: Examinations FK_Examinations_Histories_HistoryId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Examinations"
    ADD CONSTRAINT "FK_Examinations_Histories_HistoryId" FOREIGN KEY ("HistoryId") REFERENCES public."Histories"("Id") ON DELETE CASCADE;


--
-- Name: Examinations FK_Examinations_Users_UserId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Examinations"
    ADD CONSTRAINT "FK_Examinations_Users_UserId" FOREIGN KEY ("UserId") REFERENCES public."Users"("Id") ON DELETE CASCADE;


--
-- Name: Histories FK_Histories_Patients_PatientId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Histories"
    ADD CONSTRAINT "FK_Histories_Patients_PatientId" FOREIGN KEY ("PatientId") REFERENCES public."Patients"("Id") ON DELETE CASCADE;


--
-- Name: Histories FK_Histories_Users_UserId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Histories"
    ADD CONSTRAINT "FK_Histories_Users_UserId" FOREIGN KEY ("UserId") REFERENCES public."Users"("Id") ON DELETE CASCADE;


--
-- Name: Marks FK_Marks_Appointments_AppointmentId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Marks"
    ADD CONSTRAINT "FK_Marks_Appointments_AppointmentId" FOREIGN KEY ("AppointmentId") REFERENCES public."Appointments"("Id") ON DELETE CASCADE;


--
-- Name: Marks FK_Marks_Users_UserId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Marks"
    ADD CONSTRAINT "FK_Marks_Users_UserId" FOREIGN KEY ("UserId") REFERENCES public."Users"("Id") ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

--
-- Database "postgres" dump
--

--
-- PostgreSQL database dump
--

-- Dumped from database version 17.0 (Debian 17.0-1.pgdg120+1)
-- Dumped by pg_dump version 17.0 (Debian 17.0-1.pgdg120+1)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE postgres;
--
-- Name: postgres; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE postgres WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'en_US.utf8';


ALTER DATABASE postgres OWNER TO postgres;

\connect postgres

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: DATABASE postgres; Type: COMMENT; Schema: -; Owner: postgres
--

COMMENT ON DATABASE postgres IS 'default administrative connection database';


--
-- PostgreSQL database dump complete
--

--
-- PostgreSQL database cluster dump complete
--

