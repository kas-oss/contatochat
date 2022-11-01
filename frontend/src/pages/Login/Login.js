import { useContext } from 'react'

import Form from '../../components/Form/Form'
import Input from '../../components/Inputs/Input/Input'
import Button from '../../components/Button/Button'
import { UserContext } from '../../hooks/UserContext'
import LinkForm from '../../components/Links/LinkForm/LinkForm'


const Login = () => {
    const user = useContext(UserContext) 

    const onSubmit = (e) =>{        
        e.preventDefault()
        const email = e.target.email.value
        const password = e.target.password.value
        user.login(email, password)        
    }

    return (        
            <Form headerText='Login' onSubmit={onSubmit}>
                <Input type="email" name="email" placeholder="Email" className="input" />
                <Input type="password" name="password" placeholder="Senha" className="password" />
                <Button text="Login"/>
                <LinkForm message='Não possui uma conta?' link='/' textLink='Cadastre-se'/>
            </Form>
    )
}

export default Login