# Sistema de Gestión de Citas Odontológicas

## 📋 Descripción General

Sistema de Gestión de Citas Odontológicas es una aplicación de escritorio desarrollada en **C# con Windows Forms** utilizando la librería de diseño **Guna** para una interfaz moderna y profesional. El sistema permite gestionar usuarios, pacientes, dentistas, especialidades y citas en una clínica dental.

**Versión:** 1.0.0  
**Framework:** .NET Framework 4.7.2  
**Base de Datos:** SQL Server  
**Patrón de Arquitectura:** MVC (Model-View-Controller)

---

## 🎯 Características Implementadas

### 1. **Autenticación y Control de Acceso**
- ✅ Formulario de Login seguro
- ✅ Gestión de roles de usuario (Administrador, Recepcionista)
- ✅ Control de estado de usuarios (Activo/Inactivo)
- ✅ Sesión de usuario persistente durante la aplicación

### 2. **Gestión de Usuarios**
- ✅ Crear nuevos usuarios
- ✅ Editar información de usuarios existentes
- ✅ Cambiar estado de usuarios (Activo/Inactivo)
- ✅ Asignación de roles
- ✅ Generación automática de nombre de usuario basado en nombre y apellido
- ✅ Visualización de lista de usuarios activos e inactivos

### 3. **Gestión de Pacientes**
- 🔧 Formulario base implementado
- ⏳ Funcionalidades en desarrollo

### 4. **Gestión de Citas**
- 🔧 Formulario base implementado
- ⏳ Funcionalidades en desarrollo

### 5. **Gestión de Dentistas**
- 🔧 Formulario base implementado
- ⏳ Funcionalidades en desarrollo

### 6. **Gestión de Especialidades**
- 🔧 Formulario base implementado
- ⏳ Funcionalidades en desarrollo

---

## 🏗️ Arquitectura y Estructura del Proyecto

El proyecto sigue el patrón **MVC (Model-View-Controller)** para mantener la separación de responsabilidades y garantizar escalabilidad.

### Estructura de Carpetas

```
Sistema/
├── 📁 Clases/                          # Modelos y Lógica de Negocio
│   ├── 📁 ClaseConexionSQL/           # Acceso a Datos (Data Access Layer)
│   │   ├── Conexion.cs                 # Gestión de conexión a BD
│   │   └── ConsultasSQL.cs             # Consultas SQL genéricas
│   ├── 📁 ClaseUsuarios/              # Modelos de Usuarios
│   │   ├── GuardarUsuarios.cs          # Controlador de guardado de usuarios
│   │   ├── UsuarioLogeado.cs           # Modelo estático de usuario autenticado
│   │   └── SalHash.cs                  # Utilidades de criptografía PBKDF2
│   ├── 📁 ClaseLogin/                 # Autenticación
│   │   ├── ConsultarUsuario.cs         # Controlador de login
│   │   └── VerificarContraseña.cs      # Verificación segura de contraseñas
│   └── 📁 ClaseAlertas/               # Notificaciones
│       └── AlertasDelSistema.cs        # Sistema de alertas y notificaciones
│
├── 📁 Formularios/                     # Vistas (UI)
│   ├── 📁 FormLoginMenu/
│   │   ├── LoginForm.cs                # Vista: Formulario de Login
│   │   ├── LoginForm.Designer.cs
│   │   ├── MenuForm.cs                 # Vista: Menú Principal
│   │   ├── MenuForm.Designer.cs
│   │   └── InicioLOGO.cs               # Vista: Pantalla de Inicio
│   ├── 📁 FormUsuarios/
│   │   ├── FormCrearUsuarios.cs        # Vista: Gestión de Usuarios
│   │   └── FormCrearUsuarios.Designer.cs
│   ├── 📁 FormPacientes/
│   │   ├── PacientesForm.cs            # Vista: Gestión de Pacientes
│   │   └── PacientesForm.Designer.cs
│   ├── 📁 FormDentistas/
│   │   ├── DentistasForm.cs            # Vista: Gestión de Dentistas
│   │   ├── DentistasForm.Designer.cs
│   │   ├── EspecialidadesForm.cs       # Vista: Gestión de Especialidades
│   │   └── EspecialidadesForm.Designer.cs
│   └── 📁 FormCitas/
│       ├── CitasForm.cs                # Vista: Gestión de Citas
│       └── CitasForm.Designer.cs
│
├── Form1.cs                            # Formulario base (plantilla)
├── Program.cs                          # Punto de entrada de la aplicación
└── App.config                          # Configuración y cadena de conexión

```

---

## 🔒 Métodos de Seguridad Implementados

### 1. **Hash de Contraseñas con PBKDF2**
**Ubicación:** `Clases/ClaseUsuarios/SalHash.cs`

```csharp
// Algoritmo: PBKDF2 (Password-Based Key Derivation Function 2)
// Parámetros:
// - Iteraciones: 10,000 (estándar NIST)
// - Bytes de Hash: 32 (256-bit)
// - Bytes de Salt: 16 (128-bit random)
```

**Características:**
- ✅ Generación de Salt aleatorio usando `RNGCryptoServiceProvider`
- ✅ Derivación de clave con 10,000 iteraciones (previene ataques por fuerza bruta)
- ✅ Hash de 256 bits para máxima seguridad
- ✅ Cada contraseña tiene su propio Salt único

**Flujo:**
1. Usuario crea contraseña
2. Sistema genera Salt aleatorio
3. Se aplica PBKDF2(contraseña, salt, 10000 iteraciones)
4. Se almacena: Salt + Hash (nunca la contraseña en texto plano)





### 4. **Control de Acceso basado en Roles**
**Ubicación:** `Clases/ClaseUsuarios/UsuarioLogeado.cs`

```csharp
public static class UsuarioLogeado
{
    public static int User { get; set; }
    public static string Nombre { get; set; }
    public static string Apellido { get; set; }
    public static string Rol { get; set; }  // Administrador, Recepcionista
}
```

**Funcionalidad:**
- ✅ Almacena datos del usuario autenticado
- ✅ Permite validar permisos según rol
- ✅ Está disponible en toda la aplicación




## 🚀 Cómo Usar la Aplicación

### Requisitos Previos
- Visual Studio 2019 o superior
- .NET Framework 4.7.2
- SQL Server (LocalDB o completo)
- NuGet packages: Guna

### Instalación

1. **Clonar el repositorio:**
```bash
git clone https://github.com/YefriGavarrete/SistemaFacturacion.git
cd Sistema
```

2. **Restaurar paquetes NuGet:**
```bash
nuget restore
```

3. **Configurar la conexión a BD:**
   - Abrir `App.config`
   - Modificar `ConexionDB` con tu servidor SQL Server:
```xml
<add name="ConexionDB"
     connectionString="Data Source=TU_SERVIDOR\MSSQLSERVER; Initial Catalog=SistemasCitas; Integrated Security=true"
     providerName="System.Data.SqlClient"/>
```

4. **Crear la base de datos:**
   - Ejecutar los scripts SQL en tu servidor

5. **Compilar y Ejecutar:**
   - Presionar F5 o click en "Iniciar"

### Flujo de Uso

```
1. Ejecutar aplicación
   ↓
2. Pantalla de Login (InicioLOGO.cs)
   ↓
3. Ingresar credenciales
   ↓
4. Verificación PBKDF2 de contraseña
   ↓
5. Validación de estado (Activo/Inactivo)
   ↓
6. Menú Principal (MenuForm.cs)
   ├─ Gestión de Usuarios
   ├─ Gestión de Pacientes
   ├─ Gestión de Dentistas
   ├─ Gestión de Citas
   └─ Gestión de Especialidades
```

---


## 🛠️ Extensibilidad y Escalabilidad

### Patrones Utilizados

#### 1. **Repository Pattern**
- Classe `ConsultasSQL` actúa como repositorio genérico
- Métodos reutilizables: `Buscar()`, `Guardar()`, `Eliminar()`, `update()`

#### 2. **Data Access Layer (DAL)**
- Separación clara entre lógica de negocio y acceso a datos
- `ConsultasSQL.cs` centraliza todas las operaciones BD

#### 3. **Model-View-Controller (MVC)**
- **Models:** Clases en `Clases/`
- **Views:** Formularios en `Formularios/`
- **Controllers:** Lógica en clases de negocio

#### 4. **Dependency Injection**
- Las clases reciben sus dependencias
- Facilita testing y mantenimiento

## 🎨 Tecnologías y Librerías

| Tecnología | Versión | Propósito |
|-----------|---------|----------|
| .NET Framework | 4.7.2 | Runtime |
| Windows Forms | - | UI Framework |
| SQL Server | 2019+ | Base de Datos |
| Guna | Latest | Diseño Moderno |
| System.Security.Cryptography | - | PBKDF2, RNG |
| System.Data.SqlClient | - | Acceso a BD |

---

## 📊 Diagrama de Flujo - Autenticación

```
┌─────────────────┐
│  LoginForm.cs   │
│   (Usuario)     │
└────────┬────────┘
         │
         ↓
┌──────────────────────────────┐
│ ConsultarUsuario.Buscar()    │
│ (Controlador de Login)       │
└────────┬─────────────────────┘
         │
         ↓
┌──────────────────────────────┐
│ ConsultasSQL.Buscar()        │
│ (Acceso a Datos)             │
└────────┬─────────────────────┘
         │
         ↓
    [SQL Query]
    SELECT * FROM UsuariosLogin
    WHERE Usuario = @usuario
         │
         ↓
┌──────────────────────────────┐
│ VerificarContraseña.Verify() │
│ PBKDF2 en tiempo constante   │
└────────┬─────────────────────┘
         │
    ┌────┴────┐
    │          │
   ✓          ✗
   │          │
   ↓          ↓
[Success] [Error]
   │          │
   ↓          ↓
MenuForm  LoginForm
(Acceso)  (Rechazar)
```

---
Proyecto: Sistema de Gestión de Citas Odontológicas

## 📌 Notas Importantes

1. **No Almacenar Contraseñas en Texto Plano:** Siempre usar `SalHash.ComputeHash()`
2. **Usar Parámetros SQL:** Nunca concatenar cadenas en queries
3. **Validar Entrada:** Verificar campos vacíos y tipos de datos
4. **Manejo de Excepciones:** Envolver acceso a BD en try-catch
5. **Cerrar Recursos:** Usar `using` para conexiones y comandos
6. **Logs de Auditoría:** Registrar cambios importantes (en desarrollo)
7. **Contraseñas Fuertes:** Implementar validación de complejidad (en desarrollo)

---

**¡Gracias por usar Sistema de Gestión de Citas Odontológicas!**
