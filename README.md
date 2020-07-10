<div align="center"><h1 class="public  d-flex flex-wrap flex-items-center break-word float-none f3"><strong itemprop="name" class="mr-2 flex-self-stretch"><a data-pjax="#js-repo-pjax-container" href="https://github.com/Saber011/Xsolla-Summer-School-2020.-Backend">Xsolla-Summer-School-2020.-Backend</a></strong></h1></div>
<div align="center"><h3>
Серверная часть для новостной ленты<br></h3></div>Данное приложение имеет методы работы с новостями и пользователями.<br><h2 data-sourcepos="15:1-15:28" dir="auto">
Как запустить</h2>
<h3 data-sourcepos="17:1-17:88" dir="auto">
Убедитесь, что у Вас установлен версии .NET Core 3.1</h3>
<pre class="code highlight js-syntax-highlight plaintext white" lang="plaintext"><code><span id="LC1" class="line" lang="plaintext">dotnet --version</span></code></pre>
<p data-sourcepos="23:1-23:205" dir="auto">В случае ошибки выполнения команды скачайте все файлы для Вашей системы.<br></p>
<h3 data-sourcepos="25:1-25:61" dir="auto">
Запустите проект через dotnet builder</h3>
<p data-sourcepos="27:1-27:70" dir="auto">Восстановите все зависимости решения:</p>
<pre class="code highlight js-syntax-highlight plaintext white" lang="plaintext"><code><span id="LC1" class="line" lang="plaintext">dotnet restore</span></code></pre>
<p data-sourcepos="33:1-33:55" dir="auto">Перейдите в папку <em>Xsolla Summer School 2020. Backend\Xsolla Summer School 2020. Backend</em></p>
<pre class="code highlight js-syntax-highlight plaintext white" lang="plaintext"><code><span id="LC1" class="line" lang="plaintext">cd Xsolla Summer School 2020. Backend\Xsolla Summer School 2020. Backend</span></code></pre>
<p data-sourcepos="39:1-39:54" dir="auto">И запустите проект в dev режиме</p>
<pre class="code highlight js-syntax-highlight plaintext white" lang="plaintext"><code><span id="LC1" class="line" lang="plaintext">dotnet watch run</span></code></pre>
<p data-sourcepos="45:1-45:108" dir="auto">Собрать приложение (необязательно) можно с помощью команды</p>
<pre class="code highlight js-syntax-highlight plaintext white" lang="plaintext"><code><span id="LC1" class="line" lang="plaintext">dotnet build --configuration Release</span></code></pre>
<p data-sourcepos="51:1-51:24" dir="auto">Опубликовать</p>
<pre class="code highlight js-syntax-highlight plaintext white" lang="plaintext"><code><span id="LC1" class="line" lang="plaintext">dotnet publish -c Release</span></code></pre>
<p data-sourcepos="57:1-57:34" dir="auto">Для запуска тестов</p>
<pre class="code highlight js-syntax-highlight plaintext white" lang="plaintext"><code><span id="LC1" class="line" lang="plaintext">dotnet test</span></code></pre>
<p data-sourcepos="63:1-63:258" dir="auto"><em>Приложение опубликовано по адресу (Swagger): http://canuserasp-001-site1.ctempurl.com/index.html<br></em></p>
<h3 data-sourcepos="65:1-65:7" dir="auto">
IDE</h3>
<p data-sourcepos="67:1-67:219" dir="auto">Приложение разрабатывалось с использованием Visual Studio 2019 Enterprise<br></p>
<h2 data-sourcepos="69:1-69:18" dir="auto">
Что есть</h2>
<h3 data-sourcepos="71:1-71:58" dir="auto">
Авторизация и аутентификация</h3>
<p data-sourcepos="73:1-73:329" dir="auto">CRUD операции с пользователем, аутентификация и авторизация. С применением JWT токенов.<br></p>
<h3 data-sourcepos="75:1-75:112" dir="auto">
Контроллер для новостей<br></h3>
<p data-sourcepos="77:1-77:50" dir="auto">Можно посмотреть в папке</p>
<pre class="code highlight js-syntax-highlight plaintext white" lang="plaintext"><code><span id="LC1" class="line" lang="plaintext">Xsolla Summer School 2020. Backend\Controllers</span></code></pre>
<h3 data-sourcepos="83:1-83:25" dir="auto">
База данных</h3>
<p data-sourcepos="85:1-85:202" dir="auto">Для работы с базой данных используется entity framework core, позволяющий использовать асинхронные запросы, используется СУБД MSSQL.</p><h3 data-sourcepos="99:1-99:33" dir="auto">
Unit тесты</h3><br>
