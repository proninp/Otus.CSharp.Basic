PGDMP      &                }            Shop    17.2    17.2     :           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false            ;           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false            <           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false            =           1262    16950    Shop    DATABASE     z   CREATE DATABASE "Shop" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "Shop";
                     admin    false            �            1259    16952 	   customers    TABLE     �   CREATE TABLE public.customers (
    id integer NOT NULL,
    firstname character varying(50) NOT NULL,
    lastname character varying(50) NOT NULL,
    age integer NOT NULL,
    CONSTRAINT customers_age_check CHECK ((age > 0))
);
    DROP TABLE public.customers;
       public         heap r       postgres    false            �            1259    16951    customers_id_seq    SEQUENCE     �   CREATE SEQUENCE public.customers_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public.customers_id_seq;
       public               postgres    false    218            >           0    0    customers_id_seq    SEQUENCE OWNED BY     E   ALTER SEQUENCE public.customers_id_seq OWNED BY public.customers.id;
          public               postgres    false    217            �            1259    16971    orders    TABLE     �   CREATE TABLE public.orders (
    id integer NOT NULL,
    customerid integer NOT NULL,
    productid integer NOT NULL,
    quantity integer NOT NULL,
    CONSTRAINT orders_quantity_check CHECK ((quantity > 0))
);
    DROP TABLE public.orders;
       public         heap r       postgres    false            �            1259    16970    orders_id_seq    SEQUENCE     �   CREATE SEQUENCE public.orders_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 $   DROP SEQUENCE public.orders_id_seq;
       public               postgres    false    222            ?           0    0    orders_id_seq    SEQUENCE OWNED BY     ?   ALTER SEQUENCE public.orders_id_seq OWNED BY public.orders.id;
          public               postgres    false    221            �            1259    16960    products    TABLE     O  CREATE TABLE public.products (
    id integer NOT NULL,
    name character varying(100) NOT NULL,
    description text,
    stockquantity integer NOT NULL,
    price numeric(10,2) NOT NULL,
    CONSTRAINT products_price_check CHECK ((price >= (0)::numeric)),
    CONSTRAINT products_stockquantity_check CHECK ((stockquantity >= 0))
);
    DROP TABLE public.products;
       public         heap r       postgres    false            �            1259    16959    products_id_seq    SEQUENCE     �   CREATE SEQUENCE public.products_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 &   DROP SEQUENCE public.products_id_seq;
       public               postgres    false    220            @           0    0    products_id_seq    SEQUENCE OWNED BY     C   ALTER SEQUENCE public.products_id_seq OWNED BY public.products.id;
          public               postgres    false    219            �           2604    16955    customers id    DEFAULT     l   ALTER TABLE ONLY public.customers ALTER COLUMN id SET DEFAULT nextval('public.customers_id_seq'::regclass);
 ;   ALTER TABLE public.customers ALTER COLUMN id DROP DEFAULT;
       public               postgres    false    217    218    218            �           2604    16974 	   orders id    DEFAULT     f   ALTER TABLE ONLY public.orders ALTER COLUMN id SET DEFAULT nextval('public.orders_id_seq'::regclass);
 8   ALTER TABLE public.orders ALTER COLUMN id DROP DEFAULT;
       public               postgres    false    222    221    222            �           2604    16963    products id    DEFAULT     j   ALTER TABLE ONLY public.products ALTER COLUMN id SET DEFAULT nextval('public.products_id_seq'::regclass);
 :   ALTER TABLE public.products ALTER COLUMN id DROP DEFAULT;
       public               postgres    false    220    219    220            3          0    16952 	   customers 
   TABLE DATA           A   COPY public.customers (id, firstname, lastname, age) FROM stdin;
    public               postgres    false    218   �        7          0    16971    orders 
   TABLE DATA           E   COPY public.orders (id, customerid, productid, quantity) FROM stdin;
    public               postgres    false    222   �!       5          0    16960    products 
   TABLE DATA           O   COPY public.products (id, name, description, stockquantity, price) FROM stdin;
    public               postgres    false    220   �!       A           0    0    customers_id_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public.customers_id_seq', 21, true);
          public               postgres    false    217            B           0    0    orders_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.orders_id_seq', 20, true);
          public               postgres    false    221            C           0    0    products_id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public.products_id_seq', 20, true);
          public               postgres    false    219            �           2606    16958    customers customers_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.customers
    ADD CONSTRAINT customers_pkey PRIMARY KEY (id);
 B   ALTER TABLE ONLY public.customers DROP CONSTRAINT customers_pkey;
       public                 postgres    false    218            �           2606    16977    orders orders_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY public.orders
    ADD CONSTRAINT orders_pkey PRIMARY KEY (id);
 <   ALTER TABLE ONLY public.orders DROP CONSTRAINT orders_pkey;
       public                 postgres    false    222            �           2606    16969    products products_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.products
    ADD CONSTRAINT products_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.products DROP CONSTRAINT products_pkey;
       public                 postgres    false    220            �           1259    16989    idx_customers_age_index    INDEX     j   CREATE INDEX idx_customers_age_index ON public.customers USING btree (age) INCLUDE (firstname, lastname);
 +   DROP INDEX public.idx_customers_age_index;
       public                 postgres    false    218    218    218            �           1259    16988    idx_orders_customer_product    INDEX     _   CREATE INDEX idx_orders_customer_product ON public.orders USING btree (customerid, productid);
 /   DROP INDEX public.idx_orders_customer_product;
       public                 postgres    false    222    222            �           2606    16978    orders orders_customerid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.orders
    ADD CONSTRAINT orders_customerid_fkey FOREIGN KEY (customerid) REFERENCES public.customers(id) ON DELETE CASCADE;
 G   ALTER TABLE ONLY public.orders DROP CONSTRAINT orders_customerid_fkey;
       public               postgres    false    4760    222    218            �           2606    16983    orders orders_productid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.orders
    ADD CONSTRAINT orders_productid_fkey FOREIGN KEY (productid) REFERENCES public.products(id) ON DELETE CASCADE;
 F   ALTER TABLE ONLY public.orders DROP CONSTRAINT orders_productid_fkey;
       public               postgres    false    220    4763    222            3   �   x�mλN1����S�Q��ͥLM�M�J44X�H�'�.A���td�;�����X�� ߒ�^J�!��V�I�.Mo��[{ö�W����6JM����h��]΂M�[��*�|'��L+<%=�`S>B=W~Ik<�DtѲ�h�x���_� u�~���O��d�0��'�<b��͓p�ݤ�1��x�n.õ�:#�_}nk/      7   W   x�=���0�o{��&gw��s�Dq���	���XP�=+ښ���	;���܈���|�aa���Cʦ�ʪ�ʮ˲~:L����      5   O  x����n�0Dϛ���l���h�D�*A�K/��'�lS��wC�r\gvv�~^U]����d�Aզ90�˂���O�"�����m��T�Y�J�,�� /�iƓ�P�W5��3'Z5���W�'��"Ԑ�gu/&�X�J�H<����I;���Љit�JZ�.,�d	)M�E�ט�<�k�ai-[-ٿ�ü_8�5^�N�6�+��,;�k3��9�;�O��vw�?���FӧtFʩ��,`ۢ:���=at.V�u�z 7K� �q���߈����r	b��+����� HI��b<Dq'E� F� G1�IR�E)Ƴww���&I���     