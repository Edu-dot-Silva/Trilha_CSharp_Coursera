# CSS Testing & Verification Guide - Atividade 3

## 🧪 Teste de Conformidade do CSS

Este guia fornece instruções passo a passo para verificar que todos os requisitos da Atividade 3 foram implementados corretamente.

---

## 📋 Teste 1: Verificar Link CSS → HTML

### Como Testar:
1. Abra `index.html` em um editor de texto
2. Procure pela linha com `<link rel="stylesheet"`
3. Verifique se está no `<head>` section

### Resultado Esperado:
```html
<!DOCTYPE html>
<html lang="en">
<head>
    ...
    <link rel="stylesheet" href="styles.css">
    ...
</head>
```

### ✅ Verificação:
- [ ] Link está presente no `<head>`
- [ ] Href aponta para `styles.css`
- [ ] Arquivo `styles.css` está no mesmo dirétório

### Se não funcionar:
- Certifique-se que ambos arquivos estão na mesma pasta
- Verifique que o href é exatamente `href="styles.css"`
- Limpe cache do navegador (Ctrl+Shift+Delete)

---

## 🎨 Teste 2: Verificar Estilos Básicos (Body)

### Como Testar:
1. Abra `index.html` no navegador
2. Inspecione a página (F12 → Elements)
3. Procure por estilos aplicados ao `<body>`

### Resultado Esperado:
```css
font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
font-size: 16px;
line-height: 1.6;
color: #1e293b;
background-color: #f8fafc;
```

### ✅ Verificação Visual:
- [ ] Texto tem fonte clara e legível
- [ ] Espaçamento entre linhas adequado
- [ ] Cor de fundo é branca/light
- [ ] Cor do texto é escura/legível

### Se não funcionar:
- Verifique CSS file size (deve ter > 100 linhas)
- Inspecione body tag no DevTools
- Procure por erros no console

---

## 🧭 Teste 3: Verificar Header & Navigation

### Como Testar:
1. Abra site no navegador
2. Observe o header/navegação no topo

### Resultado Esperado:
- [ ] Header tem background branco
- [ ] Logo "Eduardo Dev" visível
- [ ] Navigation links horizontalmente alinhados
- [ ] Links têm spacing adequado
- [ ] Sticky navigation (permanece ao scroll)
- [ ] Hover effects nos links (mudam de cor)

### Teste Interativo:
```
1. Hover sobre "About Me", "Projects", "Skills", "Contact"
   → Esperado: Mudança de cor
2. Scroll down
   → Esperado: Header fica no topo (sticky)
3. Hover sobre links
   → Esperado: Transição suave
```

### ✅ Verificação CSS:
Em `styles.css`, procure por:
```css
header {
    position: sticky;
    top: 0;
    background-color: white;
}

.nav-links a:hover {
    color: var(--primary-color);
}
```

---

## 📝 Teste 4: Verificar About Me Section

### Como Testar:
1. Scroll para seção "About Me"
2. Observe o styling

### Resultado Esperado:
- [ ] Fundo branco/card-like
- [ ] Padding interior adequado
- [ ] Border-left azul (accent)
- [ ] Texto bem espaçado
- [ ] Paragraphs com margin entre eles

### ✅ Verificação CSS:
```css
#about-me {
    background-color: white;
    padding: 2rem;
    border-radius: 8px;
    border-left: 4px solid #2563eb;
}
```

---

## 🎴 Teste 5: Verificar Projects Card Layout

### Como Testar:
1. Scroll para seção "Projects"
2. Observe o layout dos 3 projeto cards

### Resultado Esperado:
- [ ] 3 cards em grid layout
- [ ] Cards em 3 colunas (desktop)
- [ ] Cards com shadow
- [ ] Cards com rounded corners
- [ ] Hover effect: card sobe (translateY)
- [ ] Project images responsivas

### Teste Interativo:
```
Desktop (1200px+):
→ 3 cards lado a lado

Tablet (768px):
→ 2 cards por linha (ou 1)

Mobile (375px):
→ 1 card por linha (fullwidth)
```

### ✅ Verificação CSS:
```css
.projects-container {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
    gap: 2rem;
}

.project-card:hover {
    transform: translateY(-5px);
    box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
}
```

---

## 🛠️ Teste 6: Verificar Skills Section (Pseudo-elementos)

### Como Testar:
1. Scroll para seção "Skills"
2. Observe os símbolos antes de cada skill

### Resultado Esperado:
- [ ] Símbolo "▸" antes de cada skill
- [ ] Símbolo é da cor primária (azul)
- [ ] Skills em grid (múltiplas colunas)
- [ ] Cada categoria tem title com border-top

### ✅ Verificação CSS:
```css
.skills-list li::before {
    content: '▸';
    position: absolute;
    left: 0;
    color: var(--primary-color);
    font-weight: bold;
}
```

### Teste:
- [ ] Inspecione um item `<li>` no DevTools
- [ ] Veja o `::before` pseudo-elemento
- [ ] Verifique que o símbolo aparece

---

## 📋 Teste 7: Verificar Contact Form

### Como Testar:
1. Scroll para seção "Contact"
2. Observe o styling do formulário

### Resultado Esperado:
- [ ] Campos de input têm border
- [ ] Labels são visíveis e associadas
- [ ] Placeholder text é legível
- [ ] Buttons têm styling adequado
- [ ] Focus state visível (border azul + glow)
- [ ] Form é responsivo

### Teste Interativo:
```
1. Clique no input "Full Name"
   → Esperado: Border muda para azul, glow appear
2. Tipo algo
   → Esperado: Texto aparece
3. Tab para próximo campo
   → Esperado: Focus se move
4. Clique em Submit
   → Esperado: Form action (alert atualmente)
```

### ✅ Verificação CSS:
```css
input:focus, textarea:focus {
    outline: none;
    border-color: var(--primary-color);
    box-shadow: 0 0 0 3px rgba(37, 99, 235, 0.1);
}
```

---

## 📱 Teste 8: Responsive Design (Media Queries)

### Desktop (1200px+)
**Como Testar**:
1. Abra site em desktop/tela grande
2. Verifique layout

**Resultado Esperado**:
- [ ] 3 colunas de projects
- [ ] 4 colunas de skills
- [ ] Navigation horizontal
- [ ] Hero section grande
- [ ] Footer em linha única

### Tablet (768px - 1024px)
**Como Testar**:
1. Redimensione janela para ~800px
2. Ou use DevTools: Ctrl+Shift+M → Tablet

**Resultado Esperado**:
- [ ] 2 colunas de projects
- [ ] 2 colunas de skills
- [ ] Navigation ajustado
- [ ] Padding reduzido
- [ ] Ainda em grid layout

### Mobile (375px - 480px)
**Como Testar**:
1. Redimensione janela para ~375px
2. Ou use DevTools: Ctrl+Shift+M → Mobile

**Resultado Esperado**:
- [ ] 1 coluna de projects
- [ ] 1 coluna de skills
- [ ] Navigation stacked (vertical)
- [ ] Font sizes reduzidas
- [ ] Padding reduzido
- [ ] Sem horizontal scrolling

### ✅ Verificação CSS:
Procure por media queries em `styles.css`:
```css
@media (max-width: 768px) { ... }
@media (max-width: 480px) { ... }
```

### Teste DevTools:
1. F12 → Toggle device toolbar (Ctrl+Shift+M)
2. Mude entre diferentes dispositivos
3. Verifique cada um:
   - iPhone 12
   - iPad
   - Desktop 1920

---

## 🌐 Teste 9: Cross-Browser Compatibility

### Chrome/Edge
**Como Testar**:
1. Abra site no Chrome/Edge
2. Verifique que tudo funciona

**Resultado Esperado**: ✅ 100% funcional

### Firefox
**Como Testar**:
1. Abra site no Firefox
2. Compare visual com Chrome

**Resultado Esperado**: ✅ Idêntico ou muito similar

### Safari (se disponível)
**Como Testar**:
1. Abra site no Safari
2. Verifique responsividade

**Resultado Esperado**: ✅ Funcional

### Checklist:
- [ ] Layout está igual em todos navegadores
- [ ] Colors aparecem iguais
- [ ] Transitions funcionam
- [ ] Responsive funciona
- [ ] Nenhum conteúdo quebrado

### Se Problemas:
- Firefox/Safari às vezes precisam de prefixos CSS
- Veja console (F12 → Console) por erros
- Verifique que CSS é válido

---

## 🎯 Teste 10: Hover & Focus States

### Hover Effects
**Como Testar**:
1. Passe mouse sobre:
   - Navigation links
   - Project cards
   - Buttons
   - Skill items

**Resultado Esperado**:
- [ ] Links mudam cor
- [ ] Cards sobem (translateY)
- [ ] Buttons mudam background
- [ ] Transitions são suaves (0.3s)

### Focus States (Tabbing)
**Como Testar**:
1. Pressione Tab repetidamente
2. Observe cada elemento receber focus

**Resultado Esperado**:
- [ ] Outline azul aparece em links
- [ ] Outline azul em buttons
- [ ] Outline em inputs
- [ ] Outline é visível (2px)

### Keyboard Navigation:
```
Tab → Próximo elemento
Shift+Tab → Elemento anterior
Enter → Ativa link/button
Space → Ativa button
```

---

## 🔧 Teste 11: Customização CSS Variables

### Como Testar:
1. Abra `styles.css` em editor
2. Procure por `:root { }`
3. Mude uma cor

### Teste Prático:
```css
:root {
    --primary-color: #9333ea;  /* Mude para roxo */
}
```

4. Salve arquivo
5. Refresh navegador
6. Observe que tudo muda de azul para roxo

**Resultado Esperado**:
- [ ] Changing PRIMARY_COLOR afeta header, buttons, links
- [ ] Changing BACKGROUND_COLOR afeta fundo
- [ ] Changing TEXT_DARK afeta text color

---

## ✨ Teste 12: Visualizando o Efeito Completo

### Criar uma Experiência Completa:
1. Abra site no navegador
2. Role pela página inteira
3. Observe cada seção

### Checklist Visual:
- [ ] Header com navegação clara
- [ ] Hero section com gradient
- [ ] About section com border-left
- [ ] Projects cards em grid
- [ ] Skills com categorias
- [ ] Contact form bem organizado
- [ ] Footer com links
- [ ] Smooth scrolling
- [ ] Tudo responsivo em diferentes tamanhos

---

## 🖼️ Teste 13: Print Styles

### Como Testar:
1. Abra site no navegador
2. Ctrl+P → Print Preview
3. Observe que print version é limpa

### Resultado Esperado:
- [ ] Header desaparece (não imprime)
- [ ] Footer desaparece (não imprime)
- [ ] Conteúdo é legível
- [ ] Colors são preto/branco
- [ ] Sem urls quebradas

**Em `styles.css`**:
```css
@media print {
    header, footer, .contact-form {
        display: none;
    }
}
```

---

## 🌙 Teste 14: Dark Mode

### Como Testar:
1. System Preferences → Dark Mode (macOS)
2. ou Settings → Theme → Dark (Windows)
3. Refresh site

**Resultado Esperado**:
- [ ] Site muda para dark theme automaticamente
- [ ] Cores ajustadas para legibilidade
- [ ] Contraste mantido
- [ ] Não há modo toggle (automático)

### Em CSS:
```css
@media (prefers-color-scheme: dark) {
    :root {
        --background-color: #0f172a;
        --card-background: #1e293b;
        --text-dark: #f1f5f9;
    }
}
```

---

## 📊 Teste 15: Performance CSS

### Verificar tamanho do arquivo:
1. Abra DevTools → Network
2. Refresh página
3. Procure por `styles.css`

**Resultado Esperado**:
- [ ] File size: ~15KB (minificado) ou ~25KB (não minificado)
- [ ] Load time: < 100ms
- [ ] Transferência: instant

### Verificar rendering:
1. DevTools → Performance
2. Gravação de página load
3. Procure por:
   - [ ] Paint: < 50ms
   - [ ] Composite: < 50ms
   - [ ] Nenhum layout shift

---

## 🚀 Checklist Final de Testes

### CSS Básico
- [ ] CSS linked corretamente no HTML
- [ ] Estilos de body aplicados
- [ ] Tipografia consistente
- [ ] Colors são visíveis

### Componentes
- [ ] Header está sticky
- [ ] Navigation é interativa
- [ ] Cards têm shadow e hover effects
- [ ] Form tem focus states
- [ ] Buttons são clicáveis

### Responsividade
- [ ] Desktop layout (1200px) funciona
- [ ] Tablet layout (768px) funciona
- [ ] Mobile layout (375px) funciona
- [ ] Sem horizontal scrolling
- [ ] Imagens são responsivas

### Cross-Browser
- [ ] Chrome/Edge - ✅
- [ ] Firefox - ✅
- [ ] Safari - ✅
- [ ] Mobile browsers - ✅

### Acessibilidade CSS
- [ ] Focus states visíveis
- [ ] Color contrast adequado
- [ ] Font sizes legíveis
- [ ] Spacing adequado

### Extras
- [ ] Hover effects suaves
- [ ] Transitions funcionam
- [ ] Dark mode funciona
- [ ] Print é limpo

---

## 📝 Teste com DevTools

### Abrir DevTools:
- Windows: F12 ou Ctrl+Shift+I
- Mac: Cmd+Option+I

### Inspector:
1. Selecione elemento
2. Veja CSS aplicado
3. Teste mudanças em tempo real
4. Veja computed styles

### Device Mode:
1. Ctrl+Shift+M
2. Selecione dispositivo
3. Teste responsividade
4. Veja media queries ativas

### Network:
1. Reload página
2. Observe `styles.css` loading
3. Veja size e timing

### Console:
1. Procure por erros
2. Não deve haver erros CSS
3. Warnings normais podem aparecer

---

## ✅ Quando Tudo Funciona

Se todos os testes passarem:

✅ **CSS está 100% funcional**
✅ **Responsive design funciona**
✅ **Cross-browser compatible**
✅ **Pronto para Atividade 4 (JavaScript)**

---

## ⚠️ Troubleshooting

### "Estilos não aparecem"
1. Verificar se arquivo `styles.css` existe
2. Verificar se href está correto
3. Limpar cache (Ctrl+Shift+Delete)
4. Reload página

### "Layout está quebrado em mobile"
1. Verificar media queries em CSS
2. Verificar viewport meta tag em HTML
3. Testar em DevTools device mode
4. Verificar window widths em media queries

### "Colors estão diferentes"
1. Verificar color values em CSS
2. Verificar que CSS Variables existem
3. Inspecionar elemento no DevTools
4. Testar em diferentes browsers

### "Hover effects não funcionam"
1. Verificar que `transition` existe
2. Verificar transform ou color change
3. Inspecionar `:hover` no DevTools
4. Testar com mouse, não touchpad

###"Responsividade não funciona"
1. Verificar que viewport meta tag existe no HTML
2. Verificar que media queries existem no CSS
3. Testar com DevTools device mode
4. Verificar breakpoints (768px, 480px)

---

## 🎉 Próximos Passos

Após confirmar que todos os testes passam:

1. **Documentar resultados** ✅
2. **Preparar para Atividade 4** (JavaScript)
3. **Considerar melhorias** (animações, effects)
4. **Revisar código** (comments, organization)

---

**Atividade 3 CSS Testing & Verification**
**Status**: Ready ✅
**Data**: March 30, 2026
