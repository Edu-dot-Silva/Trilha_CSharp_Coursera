# CSS Customization Examples - Advanced Styling Guide

Este arquivo mostra exemplos práticos de como customizar e estender o CSS do seu portfolio.

---

## 🎨 Exemplo 1: Mudar Cor Primária (Easy)

### Antes:
```css
:root {
    --primary-color: #2563eb;      /* Azul */
}
```

### Opção 1: Verde
```css
:root {
    --primary-color: #10b981;      /* Verde */
    --primary-dark: #059669;       /* Verde escuro */
}
```

### Opção 2: Roxo
```css
:root {
    --primary-color: #9333ea;      /* Roxo */
    --primary-dark: #7e22ce;       /* Roxo escuro */
}
```

### Opção 3: Laranja
```css
:root {
    --primary-color: #F97316;      /* Laranja */
    --primary-dark: #EA580C;       /* Laranja escuro */
}
```

### Resultado:
- Header background muda
- Button colors mudam
- Link hover colors mudam
- Border colors mudam
- Tudo muda automaticamente via CSS variables!

---

## 🎨 Exemplo 2: Mudar Font Family (Easy)

### Antes:
```css
--font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
```

### Opção 1: Arial (Clássico)
```css
--font-family: 'Arial', sans-serif;
```

### Opção 2: Georgia (Serif)
```css
--font-family: 'Georgia', 'Times New Roman', serif;
```

### Opção 3: Courier (Monospace)
```css
--font-family: 'Courier New', monospace;
```

### Opção 4: Google Fonts (Modern)
Primeiro, adicione no `<head>` do HTML:
```html
<link href="https://fonts.googleapis.com/css2?family=Poppins:wght@400;700&display=swap" rel="stylesheet">
```

Depois em CSS:
```css
--font-family: 'Poppins', sans-serif;
```

---

## 🎨 Exemplo 3: Adicionar Shadow Mais Forte (Medium)

### Padrão Atual:
```css
.project-card {
    box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
}
```

### Versão com Shadow Dramático:
```css
.project-card {
    box-shadow: 0 10px 30px rgba(0, 0, 0, 0.3);
}

.project-card:hover {
    box-shadow: 0 15px 50px rgba(0, 0, 0, 0.4);
}
```

### Resultado:
Cards têm shadow mais pronunciado, parecem "flutuar" mais

---

## 🎨 Exemplo 4: Adicionar Gradient de Fundo (Medium)

### Encontre esta seção:
```css
.hero {
    background: linear-gradient(135deg, var(--primary-color) 0%, var(--primary-dark) 100%);
}
```

### Opção 1: Gradient 3 cores
```css
.hero {
    background: linear-gradient(135deg, #2563eb 0%, #8b5cf6 50%, #ec4899 100%);
}
```

### Opção 2: Gradient horizontal
```css
.hero {
    background: linear-gradient(90deg, var(--primary-color) 0%, var(--primary-dark) 100%);
}
```

### Opção 3: Radial gradient
```css
.hero {
    background: radial-gradient(circle, var(--primary-color) 0%, var(--primary-dark) 100%);
}
```

---

## 🎨 Exemplo 5: Adicionar Efeito Border Animated (Hard)

### Adicione este CSS:
```css
.project-card {
    position: relative;
    border: 2px solid transparent;
    background-clip: padding-box;
}

.project-card::before {
    content: '';
    position: absolute;
    top: -2px;
    left: -2px;
    right: -2px;
    bottom: -2px;
    background: linear-gradient(90deg, #2563eb, #8b5cf6);
    border-radius: 8px;
    z-index: -1;
    opacity: 0;
    transition: opacity 0.3s ease;
}

.project-card:hover::before {
    opacity: 1;
}
```

### Resultado:
Cards ganham border gradient animated no hover

---

## 🎨 Exemplo 6: Adicionar Glassmorphism (Hard)

### Adicione este CSS para About Section:
```css
#about-me {
    background: rgba(255, 255, 255, 0.8);
    backdrop-filter: blur(10px);
    border: 1px solid rgba(255, 255, 255, 0.2);
    box-shadow: 0 8px 32px rgba(0, 0, 0, 0.1);
}
```

### Resultado:
Section tem efeito "glass" com blur de background

---

## 🎨 Exemplo 7: Adicionar Hover Scale Effect (Medium)

### Encontre:
```css
.project-card:hover {
    transform: translateY(-5px);
    box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
}
```

### Mude para:
```css
.project-card:hover {
    transform: translateY(-5px) scale(1.02);
    box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
}
```

### Ou mais dramático:
```css
.project-card {
    transition: transform 0.3s ease, box-shadow 0.3s ease;
}

.project-card:hover {
    transform: translateY(-10px) scale(1.05) rotate(1deg);
    box-shadow: 0 20px 40px rgba(0, 0, 0, 0.2);
}
```

---

## 🎨 Exemplo 8: Adicionar Underline Animation para Links (Medium)

### Encontre:
```css
.nav-links a {
    font-weight: 500;
    transition: color 0.3s ease;
}

.nav-links a:hover {
    color: var(--primary-color);
}
```

### Mude para:
```css
.nav-links a {
    font-weight: 500;
    transition: color 0.3s ease;
    position: relative;
}

.nav-links a::after {
    content: '';
    position: absolute;
    bottom: -5px;
    left: 0;
    width: 0;
    height: 2px;
    background-color: var(--primary-color);
    transition: width 0.3s ease;
}

.nav-links a:hover::after {
    width: 100%;
}
```

---

## 🎨 Exemplo 9: Mudar Espaçamento (Gap) (Easy)

### Antes:
```css
.nav-links {
    gap: 2rem;
}

.projects-container {
    gap: 2rem;
}
```

### Mais compacto:
```css
.nav-links {
    gap: 1rem;
}

.projects-container {
    gap: 1rem;
}
```

### Mais espaçoso:
```css
.nav-links {
    gap: 3rem;
}

.projects-container {
    gap: 3rem;
}
```

---

## 🎨 Exemplo 10: Adicionar Ícones com Emojis (Easy)

### Encontre:
```css
.skills-list li::before {
    content: '▸';
    position: absolute;
    left: 0;
    color: var(--primary-color);
    font-weight: bold;
}
```

### Mude para:
```css
.skills-list li::before {
    content: '⭐';  /* Star */
    position: absolute;
    left: 0;
    color: var(--primary-color);
}
```

### Outras opções:
```css
content: '✓';    /* Checkmark */
content: '→';    /* Arrow */
content: '◆';    /* Diamond */
content: '●';    /* Circle */
content: '★';    /* Star */
content: '✓';    /* Check */
```

---

## 🎨 Exemplo 11: Adicionar Button Gradient (Medium)

### Encontre:
```css
.btn-primary {
    background-color: var(--primary-color);
    color: white;
}
```

### Mude para:
```css
.btn-primary {
    background: linear-gradient(135deg, var(--primary-color) 0%, var(--primary-dark) 100%);
    color: white;
    border: none;
}

.btn-primary:hover {
    background: linear-gradient(135deg, var(--primary-dark) 0%, var(--primary-color) 100%);
}
```

---

## 🎨 Exemplo 12: Adicionar Section Dividers (Easy)

### Encontre:
```css
section h2 {
    text-align: center;
    margin-bottom: 2rem;
}
```

### Mude para:
```css
section h2 {
    text-align: center;
    margin-bottom: 2rem;
    position: relative;
    padding-bottom: 1rem;
}

section h2::after {
    content: '';
    position: absolute;
    bottom: 0;
    left: 50%;
    transform: translateX(-50%);
    width: 100px;
    height: 3px;
    background: linear-gradient(90deg, transparent, var(--primary-color), transparent);
    border-radius: 2px;
}
```

---

## 🎨 Exemplo 13: Adicionar Custom Input Focus (Medium)

### Encontre:
```css
input[type="text"]:focus,
input[type="email"]:focus,
textarea:focus {
    outline: none;
    border-color: var(--primary-color);
    box-shadow: 0 0 0 3px rgba(37, 99, 235, 0.1);
}
```

### Mude para (mais colorido):
```css
input[type="text"]:focus,
input[type="email"]:focus,
textarea:focus {
    outline: none;
    border-color: var(--primary-color);
    box-shadow: 0 0 0 4px rgba(37, 99, 235, 0.2),
                0 0 8px rgba(37, 99, 235, 0.4);
    transform: scale(1.01);
}
```

---

## 🎨 Exemplo 14: Adicionar Loading Animation (Hard)

### Crie esta nova classe:
```css
@keyframes shimmer {
    0% {
        background-position: -1000px 0;
    }
    100% {
        background-position: 1000px 0;
    }
}

.loading {
    background: linear-gradient(90deg, #f0f0f0 25%, #e0e0e0 50%, #f0f0f0 75%);
    background-size: 1000px 100%;
    animation: shimmer 2s infinite;
}
```

### Use assim:
```html
<div class="project-card loading">
    <!-- Custom loading state -->
</div>
```

---

## 🎨 Exemplo 15: Adicionar Scroll Animation (Hard)

### Adicione ao CSS:
```css
@keyframes fadeInUp {
    from {
        opacity: 0;
        transform: translateY(30px);
    }
    to {
        opacity: 1;
        transform: translateY(0);
    }
}

section {
    animation: fadeInUp 0.6s ease-out;
}

.project-card {
    animation: fadeInUp 0.6s ease-out;
    animation-fill-mode: both;
}

.project-card:nth-child(1) { animation-delay: 0.1s; }
.project-card:nth-child(2) { animation-delay: 0.2s; }
.project-card:nth-child(3) { animation-delay: 0.3s; }
```

---

## 🎨 Exemplo 16: Adicionar Mobile Menu Toggle Styling (Hard)

### Para uma futura hamburger menu, adicione:
```css
.hamburger {
    display: none;
    flex-direction: column;
    cursor: pointer;
    gap: 5px;
}

.hamburger span {
    width: 25px;
    height: 3px;
    background-color: var(--text-dark);
    border-radius: 3px;
    transition: all 0.3s ease;
}

.hamburger.active span:nth-child(1) {
    transform: rotate(45deg) translateY(10px);
}

.hamburger.active span:nth-child(2) {
    opacity: 0;
}

.hamburger.active span:nth-child(3) {
    transform: rotate(-45deg) translateY(-10px);
}

@media (max-width: 768px) {
    .hamburger {
        display: flex;
    }

    .nav-links {
        flex-direction: column;
        position: absolute;
        top: 70px;
        left: 0;
        width: 100%;
        background-color: white;
        display: none;
    }

    .nav-links.active {
        display: flex;
    }
}
```

---

## 📊 Comparação de Exemplo: Antes vs Depois

### Exemplo: Project Card Hover

#### Antes (Original):
```css
.project-card:hover {
    transform: translateY(-5px);
    box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
}
```

#### Depois (Avançado):
```css
.project-card {
    transition: all 0.3s cubic-bezier(0.25, 0.46, 0.45, 0.94);
}

.project-card:hover {
    transform: translateY(-10px) scale(1.02) rotate(2deg);
    box-shadow: 0 20px 40px rgba(37, 99, 235, 0.2);
    background-color: rgba(37, 99, 235, 0.05);
}

.project-card::after {
    content: '';
    position: absolute;
    inset: 0;
    background: linear-gradient(135deg, rgba(255,255,255,0.1) 0%, rgba(255,255,255,0) 100%);
    opacity: 0;
    transition: opacity 0.3s ease;
}

.project-card:hover::after {
    opacity: 1;
}
```

---

## 🎯 Recomendações de Customização

### Para um Portfolio Professional:
```css
/* Keep it simple blue */
--primary-color: #2563eb;
--shadow: subtle
--transitions: 0.3s
/* Clean, minimal design */
```

### Para um Portfolio Creative:
```css
/* Bold purple or gradient */
--primary-color: #9333ea;
--shadow: dramatic
--transitions: 0.5s
/* Lots of animations */
```

### Para um Portfolio Tech/Dev:
```css
/* Dark mode friendly */
--primary-color: #3b82f6;
--shadow: minimal
--transitions: 0.2s
/* Fast, efficient design */
```

### Para um Portfolio Startup:
```css
/* Modern gradient */
--primary-color: #10b981;
--shadow: modern
--transitions: 0.4s
/* Trendy design */
```

---

## 🔍 Como Implementar

### Passo 1: Escolha um exemplo
### Passo 2: Copie o CSS
### Passo 3: Abra `styles.css` em editor
### Passo 4: Encontre a seção relevante
### Passo 5: Cole o novo CSS
### Passo 6: Salve o arquivo
### Passo 7: Refresh no navegador

---

## ⚠️ Tips Importantes

✅ **DO:**
- Teste em múltiplos navegadores
- Mantenha performance em mente
- Use CSS variables para consistência
- Documente mudanças importantes
- Preserve acessibilidade

❌ **DON'T:**
- Não deixe CSS muito complexo
- Não esqueça de testes responsivos
- Não remova focus states
- Não use muitas animações
- Não quebre o layout

---

## 📝 Próximas Explorações

Para aprender mais, explore:
1. **CSS Grid Avançado** - Layout complexos
2. **CSS Animations** - Movimentos controlados
3. **CSS Transitions** - Smooth changes
4. **CSS Filters** - Image effects
5. **CSS Transforms** - 3D effects
6. **CSS Blend Modes** - Layer blending

---

**CSS Customization Guide**
**Status**: Reference Ready ✅
**Última Atualização**: March 30, 2026
