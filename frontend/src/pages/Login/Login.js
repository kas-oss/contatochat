import { useContext } from 'react'
import './Login.css'

import Form from '../../components/Form/Form'
import Input from '../../components/Inputs/Input/Input'
import Button from '../../components/Button/Button'
import { UserContext } from '../../hooks/UserContext'


const Login = () => {
    const user = useContext(UserContext) 

    const onSubmit = (e) =>{        
        e.preventDefault()
        const email = e.target.email.value
        const password = e.target.password.value
        user.login(email, password)        
    }

    return (
        <section className="container forms">
            <Form onSubmit={onSubmit}>
                <Input type="email" name="email" placeholder="Email" className="input" />
                <Input type="password" name="password" placeholder="Senha" className="password" />
                <Button text="Login"/>
                <div className="form-link">
                    <span>Não possui uma conta? <a href="/" className="link signup-link">Cadastre-se</a></span>
                </div>
            </Form>
        </section>
    )
}

export default Login